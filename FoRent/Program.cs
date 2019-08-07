using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FoRent.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FoRent
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
            var host = BuildWebHost(args);


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                
                FoRentContext context = services.GetRequiredService<FoRentContext>();

                for(int i=1;i<94;i++)
                {
                    DateTime dateTime =DateTime.Now;
                    context.Add(new Availability() {NotAvailable= dateTime, Id=i });
                    context.SaveChanges();
                    dateTime = dateTime.AddDays(1);
                }
            }

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


    }
}
