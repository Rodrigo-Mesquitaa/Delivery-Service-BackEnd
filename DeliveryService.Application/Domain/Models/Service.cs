using System.Collections.Generic;

namespace DeliveryService.Application.Domain.Models
{
    public class Service
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual List<Route> Routes { get; private set; }
        //public virtual List<Route> ReverseRoutes { get; private set; }


        public Service(string name)
        {
            Name = name;
            Routes = new List<Route>();
        }

        public Service(int id, string name)
        {
            Id = id;
            Name = name;
            Routes = new List<Route>();
        }

        public Service(int id, string name, List<Route> routes)
        {
            Id = id;
            Name = name;
            Routes = routes;
        }

        public Service(string name, List<Route> routes)
        {
            Name = name;
            Routes = routes;
        }

        public void AddRoutes(List<Route> routes)
        {
            Routes = routes;
        }

    }
}