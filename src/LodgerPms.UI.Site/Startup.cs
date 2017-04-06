using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using LodgerPms.Infra.CrossCutting.IoC;
using LodgerPms.Infra.CrossCutting.Bus;
using LodgerPms.DepartmentsDataLayer.Context;
using LodgerPms.Infra.CrossCutting.Identity.Models;
using AutoMapper;
using LodgerPms.Infra.CrossCutting.Identity.Authorization;
using LodgerPms.Infra.CrossCutting.Identity.Data;
using LodgerPms.EventStoreSqlDataLayer.Context;
using LodgerPms.RoomsDataLayer;
using LodgerPms.RoomsDataLayer.Context;

namespace LodgerPms.UI.Site
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                builder.AddUserSecrets("test");
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        { 
                services.AddDbContext<EventStoreSQLContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("EventStoreSQLContextDB")));

            
            services.AddDbContext<RoomsContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("RoomsContextDB")));


            services.AddDbContext<ApplicationDbContext>(options =>
                  options.UseSqlServer(Configuration.GetConnectionString("ApplicationDbContextDB")));

            services.AddDbContext<DepartmentsContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DepartmentsContextDB")));

            var test = Configuration.GetConnectionString("LodgerPmsDatabase");

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                    options.Cookies.ApplicationCookie.AccessDeniedPath = "/home/access-denied")
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();
           services.AddAutoMapper();


            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanWriteDepartmentData", policy => policy.Requirements.Add(new ClaimRequirement("Departments", "Write")));
                options.AddPolicy("CanRemoveDepartmentData", policy => policy.Requirements.Add(new ClaimRequirement("Departments", "Remove")));
            });

            // .NET Native DI Abstraction
            RegisterServices(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            ILoggerFactory loggerFactory, IHttpContextAccessor accessor, DepartmentsContext deptoCntxt, RoomsContext cntxt)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseIdentity();

            app.UseFacebookAuthentication(new FacebookOptions()
            {
                AppId = "SetYourDataHere",
                AppSecret = "SetYourDataHere"
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=welcome}/{id?}");
            });

            // Setting the IContainer interface for use like service locator for events.
            InMemoryBus.ContainerAccessor = () => accessor.HttpContext.RequestServices;
            
            
            //data seeding 
            DepartmentsDataLayer.DbInitializer.Initialize(deptoCntxt);
            RoomsDataLayer.DbInitializer.Initialize(cntxt);


        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            SimpleInjectorBootStrapper.RegisterServices(services);
        }
    }
}
