

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Parts.API;
using Parts.API.Domain.Models;

namespace PartsAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);

            // using (var scope = host.Services.CreateScope())
            // using (var context = scope.ServiceProvider.GetService<PartsDBContext>())
            // {
            //     //context.Database.EnsureCreated();
            // }

            // host.Run();
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                    .Build();
    }
}
