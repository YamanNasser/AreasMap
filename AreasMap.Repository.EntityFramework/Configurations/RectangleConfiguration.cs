using AreasMap.Domain.Entities.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AreasMap.Repository.EntityFramework.Configurations
{
    public class RectangleConfiguration : IEntityTypeConfiguration<Rectangle>
    {
        public void Configure(EntityTypeBuilder<Rectangle> builder)
        {
            builder.HasOne(x => x.Bounds)
         .WithOne(m => m.Rectangle)
         .HasForeignKey<Rectangle>(x => x.BoundsId);
        }
    }
}