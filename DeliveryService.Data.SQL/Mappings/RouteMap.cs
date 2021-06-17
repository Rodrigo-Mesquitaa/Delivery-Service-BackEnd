using DeliveryService.Application.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeliveryService.Data.SQL.Mappings
{
    public class RouteMap : IEntityTypeConfiguration<Route>
    {
        void IEntityTypeConfiguration<Route>.Configure(EntityTypeBuilder<Route> builder)
        {
            builder.ToTable("Route");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Cost).IsRequired();
            builder.Property(x => x.Time).IsRequired();
            builder.Property(x => x.ServiceDestinationId).IsRequired();
            builder.Property(x => x.ServiceOriginId).IsRequired();

            //builder.HasOne(x => x.ServiceDestination).WithMany(x => x.Routes);
            //builder.HasOne(x => x.ServiceOrigin).WithMany(x => x.ReverseRoutes);

        }

    }
}
