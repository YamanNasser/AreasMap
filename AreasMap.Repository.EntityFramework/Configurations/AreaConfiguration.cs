using AreasMap.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AreasMap.Repository.EntityFramework.Configurations
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasOne(x => x.Shape)
         .WithOne(m => m.Area)
         .HasForeignKey<Area>(x => x.ShapeId);
        }
    }
}