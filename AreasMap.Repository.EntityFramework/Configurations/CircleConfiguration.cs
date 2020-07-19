using AreasMap.Domain.Entities.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AreasMap.Repository.EntityFramework.Configurations
{
    public class CircleConfiguration : IEntityTypeConfiguration<Circle>
    {
        public void Configure(EntityTypeBuilder<Circle> builder)
        {
            builder.HasOne(x => x.Coordinate)
         .WithOne(m => m.Circle)
         .HasForeignKey<Circle>(x => x.CoordinateId);
        }
    }
}