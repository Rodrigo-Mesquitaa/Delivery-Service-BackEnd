using DeliveryService.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryService.Data.SQL.Mappings
{
    public class ServiceMap : IEntityTypeConfiguration<Service>
    {
        void IEntityTypeConfiguration<Service>.Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("ServiceRoute");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name").IsRequired();

            //builder.HasMany(x => x.Routes).WithOne(x => x.ServiceDestination).HasForeignKey(x => x.ServiceDestinationId);
            //builder.HasMany(x => x.ReverseRoutes).WithOne(x => x.ServiceOrigin).HasForeignKey(x => x.ServiceOriginId);

        }

    }
}
