using AreasMap.Domain.Entities.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AreasMap.Repository.EntityFramework.Configurations
{
    public class RectangleBoundsConfiguration : IEntityTypeConfiguration<RectangleBounds>
    {
        public void Configure(EntityTypeBuilder<RectangleBounds> builder)
        {
            builder.HasOne(x => x.Rectangle)
            .WithOne(m => m.Bounds)
            .HasForeignKey<RectangleBounds>(x => x.RectangleId);
        }
    }
}