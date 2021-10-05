using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppConfiguration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>                
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                        var settings = config.Build();
                        config.AddAzureAppConfiguration("Endpoint=https://appconfig1000.azconfig.io;Id=4WBS-l4-s0:8b6Z8bmQAPd7MHAFL/Xw;Secret=/Z+att3usu6GG0gm3XgP2U6dDClFGl3Ur3xgxLHj/00=");
                    })                 
                   .UseStartup<Startup>());                
    }
}
