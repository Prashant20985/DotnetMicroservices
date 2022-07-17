using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder application)
        {
            using (var serviceScope = application.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data....");

                context.Platforms.AddRange(
                        new Platform() {Name=".Net", Publisher="Microsoft", Cost="free" },
                        new Platform() {Name="SQl Server", Publisher="Microsoft", Cost="free" },
                        new Platform() {Name="Kubernetes", Publisher="Cloud Native Computing Foundation", Cost="free" }
                );

                context.SaveChanges();

            }
            else
            {
                Console.WriteLine("--> We already have Data");
            }
        }
    }
}
