using AreasMap.Domain.Entities.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AreasMap.Repository.EntityFramework.Configurations
{
    public class PolygonCoordinateConfiguration : IEntityTypeConfiguration<PolygonCoordinate>
    {
        public void Configure(EntityTypeBuilder<PolygonCoordinate> builder)
        {
            builder.HasOne(x => x.Polygon)
              .WithOne(m => m.Coordinate)
              .HasForeignKey<PolygonCoordinate>(x => x.PolygonId);
        }
    }
}