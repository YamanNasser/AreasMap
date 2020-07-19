using AreasMap.Domain.Entities.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AreasMap.Repository.EntityFramework.Configurations
{
    public class CircleCoordinateConfiguration : IEntityTypeConfiguration<CircleCoordinate>
    {
        public void Configure(EntityTypeBuilder<CircleCoordinate> builder)
        {
            builder.HasOne(x => x.Circle)
         .WithOne(m => m.Coordinate)
         .HasForeignKey<CircleCoordinate>(x => x.CircleId);
        }
    }
}