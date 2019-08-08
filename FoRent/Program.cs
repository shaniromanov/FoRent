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
           
            var host = BuildWebHost(args);


            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                FoRentContext context = services.GetRequiredService<FoRentContext>();
                if (context.Availability.Count() > 0 && context.Availability.OrderBy(u => u.Id).FirstOrDefault().NotAvailable < DateTime.Now)
                {
                    foreach (var remove in context.Availability)
                    {
                        context.Availability.Remove(remove);
                    }

                }
                if (context.Availability.Count() == 0)
                {
                    DateTime dateTime = DateTime.Now.Date;
                    
                    for (int i = 1; i < 94; i++)
                    {
                        
                        context.Availability.Add(new Availability() { NotAvailable = dateTime });
                        context.SaveChanges();
                        dateTime = dateTime.AddDays(1);
                    }

                }
            }
                host.Run();
                BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


    }
}
