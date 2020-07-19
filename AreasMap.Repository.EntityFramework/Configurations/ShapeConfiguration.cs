using AreasMap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AreasMap.Repository.EntityFramework.Configurations
{
    public class ShapeConfiguration : IEntityTypeConfiguration<Shape>
    {
        public void Configure(EntityTypeBuilder<Shape> builder)
        {
            builder.HasOne(x => x.Area)
         .WithOne(m => m.Shape)
         .HasForeignKey<Shape>(x => x.AreaId);
        }
    }
}