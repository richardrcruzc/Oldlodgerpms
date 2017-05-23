 
namespace LodgerPms.Departments.Api
{    
    using global::LodgerPms.Departments.Api.IntegrationEvents;
    using global::LodgerPms.Departments.Api.Infrastructure;
    using global::LodgerPms.Departments.Api.Infrastructure.Filters;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus.Abstractions;
    using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBusRabbitMQ;
    using Microsoft.LodgerPmsContainers.BuildingBlocks.IntegrationEventLogEF;
    using Microsoft.LodgerPmsContainers.BuildingBlocks.IntegrationEventLogEF.Services;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.HealthChecks;
    using Microsoft.Extensions.Logging; 
    using System;
    using System.Data.Common;
    using System.Reflection;
    using LodgerPms.Service.Departments.Api.Infrastructure; 
    using System.Data.SqlClient;
    using Microsoft.Extensions.Options;
    using Microsoft.EntityFrameworkCore.Infrastructure;
   using RabbitMQ.Client;
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.Http;
    using LodgerPms.Departments.Api.Infrastructure.Services;
    using Microsoft.LodgerPmsContainers.BuildingBlocks.EventBus;
    using LodgerPms.Departments.Api.Infrastructure.AutofacModules; 

    public class Startup
    {
       
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile($"settings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"settings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets(typeof(Startup).GetTypeInfo().Assembly);
            }

            builder.AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
 
           
         public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices(); //Injecting Controllers themselves thru DI
                                           //For further info see: http://docs.autofac.org/en/latest/integration/aspnetcore.html#controllers-as-services

            services.AddHealthChecks(checks =>
            {
                var minutes = 1;
                if (int.TryParse(Configuration["HealthCheck:Timeout"], out var minutesParsed))
                {
                    minutes = minutesParsed;
                }
                checks.AddSqlCheck("DepartmentDb", Configuration["ConnectionString"]);
            });


            services.AddEntityFrameworkSqlServer()
                               .AddDbContext<DepartmentContext>(options =>
                               {
                                   options.UseSqlServer(Configuration["ConnectionString"],
                                       sqlServerOptionsAction: sqlOptions =>
                                       {
                                           sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                           sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                       });
                               },
                                   ServiceLifetime.Scoped  //Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
                               );

            
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SingleApiVersion(new Swashbuckle.Swagger.Model.Info()
                {
                    Title = "LodgerPmsContainers - Department HTTP API",
                    Version = "v1",
                    Description = "The department Microservice HTTP API. This is a Data-Driven/CRUD",
                    TermsOfService = "Terms Of Service"
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });


            // Add application services.
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IIdentityService, IdentityService>();
            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new IntegrationEventLogService(c));
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IOptionsSnapshot<DepartmentSettings>>().Value;
            services.AddTransient<IDepartmentIntegrationEventService, DepartmentIntegrationEventService>();

            services.AddSingleton<IRabbitMQPersistentConnection>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<DefaultRabbitMQPersistentConnection>>();

                var factory = new ConnectionFactory()
                {
                    HostName = Configuration["EventBusConnection"]
                };

                return new DefaultRabbitMQPersistentConnection(factory, logger);
            });

            services.AddSingleton<IEventBusSubscriptionsManager, InMemoryEventBusSubscriptionsManager>();
            services.AddSingleton<IEventBus, EventBusRabbitMQ>();


            services.AddOptions();


            //configure autofac

            var container = new ContainerBuilder();
            container.Populate(services);

            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new ApplicationModule(Configuration["ConnectionString"]));

            return new AutofacServiceProvider(container.Build());

        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Configure logs

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("CorsPolicy");

            ConfigureAuth(app);

            app.UseMvcWithDefaultRoute();

            app.UseSwagger()
              .UseSwaggerUi();

            var context = (DepartmentContext)app
                        .ApplicationServices.GetService(typeof(DepartmentContext));

            WaitForSqlAvailability(context, loggerFactory);

            //Seed Data
            DepartmentContextSeed.SeedAsync(app, loggerFactory).Wait();

            var integrationEventLogContext = new IntegrationEventLogContext(
                new DbContextOptionsBuilder<IntegrationEventLogContext>()
                .UseSqlServer(Configuration["ConnectionString"], b => b.MigrationsAssembly("LodgerPms.Departments.Api"))
                .Options);
            integrationEventLogContext.Database.Migrate();
        }

        protected virtual void ConfigureAuth(IApplicationBuilder app)
        {
            var identityUrl = Configuration.GetValue<string>("IdentityUrl");
            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {                 
                Authority = identityUrl.ToString(),
                ScopeName = "Department",
                RequireHttpsMetadata = false
            });
        }

        private void WaitForSqlAvailability(DepartmentContext ctx, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            try
            {
                ctx.Database.OpenConnection();
            }
            catch (SqlException ex)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger(nameof(Startup));
                    log.LogError(ex.Message);
                    WaitForSqlAvailability(ctx, loggerFactory, retryForAvailability);
                }
            }
            finally
            {
                ctx.Database.CloseConnection();
            }


        }

    }

}
