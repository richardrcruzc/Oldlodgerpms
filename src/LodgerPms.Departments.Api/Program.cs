using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace LodgerPms.Departments.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var host = new WebHostBuilder()
            //    .UseKestrel()
            //    .UseContentRoot(Directory.GetCurrentDirectory())
            //    .UseStartup<Startup>()
            //    .UseApplicationInsights()
            //    .Build();


            var host = new WebHostBuilder()
               .UseKestrel()
               .UseHealthChecks("/hc")
               .UseIISIntegration()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseWebRoot("Pics")
               .UseStartup<Startup>()
               .Build();

            host.Run();
        }
    }
}
