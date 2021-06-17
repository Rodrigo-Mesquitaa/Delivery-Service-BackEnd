using DeliveryService.Application.Domain.Interfaces;
using DeliveryService.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Data.SQL.Repositories
{
    public class ServiceRepository :
    Repository<Service>,
    IServiceRepository
    {
        public ServiceRepository(DbContext context) : base(context) => this.Db = context;
    }

}
