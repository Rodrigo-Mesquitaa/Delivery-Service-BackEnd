using System;
using System.Collections.Generic;
using DeliveryService.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Data.SQL.Tools
{
    public class Seed
    {
        private readonly DbContext context;

        public Seed(DbContext context)
        {
            this.context = context;
        }

        public void SeedServiceRoutes()
        {
            try
            {
                var data = GetServices();

                foreach (var item in data)
                {
                    context.Add<Service>(item);
                }

                // save services to generate Ids
                context.SaveChanges();

                foreach (var item in data)
                {
                    switch (item.Name.ToUpper())
                    {
                        case "A":
                            context.Add<Route>(CreateRoute(item.Id, 3, 1, 20));
                            context.Add<Route>(CreateRoute(item.Id, 5, 30, 5));
                            context.Add<Route>(CreateRoute(item.Id, 8, 10, 1));
                            break;

                        case "C":
                            context.Add<Route>(CreateRoute(item.Id, 2, 1, 12));
                            break;

                        case "D":
                            context.Add<Route>(CreateRoute(item.Id, 6, 4, 50));
                            break;

                        case "E":
                            context.Add<Route>(CreateRoute(item.Id, 4, 3, 5));
                            break;

                        case "F":
                            context.Add<Route>(CreateRoute(item.Id, 7, 45, 50));
                            context.Add<Route>(CreateRoute(item.Id, 9, 40, 50));
                            break;

                        case "G":
                            context.Add<Route>(CreateRoute(item.Id, 2, 64, 73));
                            break;

                        case "H":
                            context.Add<Route>(CreateRoute(item.Id, 6, 4, 50));
                            break;

                        case "I":
                            context.Add<Route>(CreateRoute(item.Id, 2, 65, 5));
                            break;

                        default:
                            break;
                    }
                }

                context.SaveChanges();

            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

        private Route CreateRoute(int originId, int destinationId, int time, int cost)
        {
            return new Route(destinationId, originId, time, cost);
        }

        private IEnumerable<Service> GetServices()
        {

            var services = new List<Service>();

            services.Add(new Service("A"));
            services.Add(new Service("B"));
            services.Add(new Service("C"));
            services.Add(new Service("D"));
            services.Add(new Service("E"));
            services.Add(new Service("F"));
            services.Add(new Service("G"));
            services.Add(new Service("H"));
            services.Add(new Service("I"));

            return services;
        }

        private void InsertRoutes(Service service, List<int> routes)
        {

        }
    }

}
