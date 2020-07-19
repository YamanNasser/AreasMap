using AreasMap.Domain.Entities;
using AreasMap.Repository.Core.Interfaces;
using AreasMap.Repository.EntityFramework.Common;
using AreasMap.Repository.EntityFramework.Context;

namespace AreasMap.Repository.EntityFramework.ShapRepository
{
    public class ShapeRepository : Repository<Shape>, IShapeRepository
    {
        public ShapeRepository(AreasMapCoreDbContext context)
            : base(context)
        {
        }
    }
}