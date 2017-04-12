 
namespace LodgerPms.Departments.Api
{ 
    using Autofac;
    using Autofac.Extensions.DependencyInjection;
    using global::LodgerPms.Departments.Api.IntegrationEvents;
    using Infrastructure; 
    using Infrastructure.Filters;
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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.

            services.AddHealthChecks(checks =>
            {
                checks.AddSqlCheck("DepartmentDb", Configuration["ConnectionString"]);
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(HttpGlobalExceptionFilter));
            }).AddControllersAsServices();

            services.AddDbContext<DepartmentContext>(options =>
            {
                options.UseSqlServer(Configuration["ConnectionString"],
                                     sqlServerOptionsAction: sqlOptions =>
                                     {
                                         sqlOptions.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                                         //Configuring Connection Resiliency: https://docs.microsoft.com/en-us/ef/core/miscellaneous/connection-resiliency 
                                         sqlOptions.EnableRetryOnFailure(maxRetryCount: 5, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                     });
                // Changing default behavior when client evaluation occurs to throw. 
                // Default in EF Core would be to log a warning when client evaluation is performed.
                options.ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.QueryClientEvaluationWarning));
                //Check Client vs. Server evaluation: https://docs.microsoft.com/en-us/ef/core/querying/client-eval
            });

            services.Configure<Settings>(Configuration);

            // Add framework services.
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SingleApiVersion(new Swashbuckle.Swagger.Model.Info()
                {
                    Title = "LodgerPmsContainers - Department HTTP API",
                    Version = "v1",
                    Description = "The department Microservice HTTP API. This is a Data-Driven/CRUD microservice sample",
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

            services.AddTransient<Func<DbConnection, IIntegrationEventLogService>>(
                sp => (DbConnection c) => new IntegrationEventLogService(c));
            var serviceProvider = services.BuildServiceProvider();
            var configuration = serviceProvider.GetRequiredService<IOptionsSnapshot<Settings>>().Value;
            services.AddTransient<IDepartmentIntegrationEventService, DepartmentIntegrationEventService>();
            services.AddSingleton<IEventBus>(new EventBusRabbitMQ(configuration.EventBusConnection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //Configure logs

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("CorsPolicy");

            app.UseMvcWithDefaultRoute();

            app.UseSwagger()
              .UseSwaggerUi();

            var context = (DepartmentContext)app
                        .ApplicationServices.GetService(typeof(DepartmentContext));

            WaitForSqlAvailability(context, loggerFactory);
            //Seed Data
            DepartmentContextSeed.SeedAsync(app, loggerFactory)
            .Wait();

            var integrationEventLogContext = new IntegrationEventLogContext(
                new DbContextOptionsBuilder<IntegrationEventLogContext>()
                .UseSqlServer(Configuration["ConnectionString"], b => b.MigrationsAssembly("LodgerPms.Departments.Api"))
                .Options);
            integrationEventLogContext.Database.Migrate();
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
