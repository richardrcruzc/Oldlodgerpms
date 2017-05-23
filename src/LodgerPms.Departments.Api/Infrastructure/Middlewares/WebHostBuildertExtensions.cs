using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LodgerPms.Departments.Api.Infrastructure.Middlewares
{
    public static class WebHostBuildertExtensions
    {
        public static IWebHostBuilder UseFailing(this IWebHostBuilder builder, string path)
        {
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<IStartupFilter>(new FailingStartupFilter());
            });
            return builder;
        }

    }
}
