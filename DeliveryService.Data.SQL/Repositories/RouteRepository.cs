using DeliveryService.Application.Domain.Interfaces;
using DeliveryService.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Data.SQL.Repositories
{

    public class RouteRepository :
    Repository<Route>, IRouteRepository
    {
        public RouteRepository(DbContext context) : base(context) => this.Db = context;
    }
}
