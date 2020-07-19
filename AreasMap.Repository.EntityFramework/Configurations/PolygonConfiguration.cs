using AreasMap.Domain.Entities.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AreasMap.Repository.EntityFramework.Configurations
{
    public class PolygonConfiguration : IEntityTypeConfiguration<Polygon>
    {
        public void Configure(EntityTypeBuilder<Polygon> builder)
        {
            builder.HasOne(x => x.Coordinate)
               .WithOne(m => m.Polygon)
               .HasForeignKey<Polygon>(x => x.CoordinateId);
        }
    }
}