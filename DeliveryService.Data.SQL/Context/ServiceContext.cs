using DeliveryService.Data.SQL.Mappings;
using Microsoft.EntityFrameworkCore;

namespace DeliveryService.Data.SQL.Context
{
    public class ServiceContext : DbContext
    {
        public ServiceContext() { }

        public ServiceContext(DbContextOptions options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ServiceMap());
            modelBuilder.ApplyConfiguration(new RouteMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///if para não realizar a configuração no caso do teste unitário por exemplo
            //if (!optionsBuilder.IsConfigured)
            //{
            //    var config = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json")
            //    .AddEnvironmentVariables()
            //    .Build();

            //    var connectionString = config.GetConnectionString("DefaultConnection");

            //    optionsBuilder.UseSqlServer(connectionString);
            //}
        }
    }
}
