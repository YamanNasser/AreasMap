using AreasMap.Domain.Entities.Shapes;
using AreasMap.Repository.Core.Interfaces;
using AreasMap.Repository.EntityFramework.Common;
using AreasMap.Repository.EntityFramework.Context;

namespace AreasMap.Repository.EntityFramework.ShapRepository
{
    public class PolygonRepository : Repository<Polygon>, IPolygonRepository
    {
        public PolygonRepository(AreasMapCoreDbContext context)
            : base(context)
        {
        }
    }
}