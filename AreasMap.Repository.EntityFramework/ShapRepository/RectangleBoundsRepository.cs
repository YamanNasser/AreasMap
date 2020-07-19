using AreasMap.Domain.Entities.Shapes;
using AreasMap.Repository.Core.Interfaces;
using AreasMap.Repository.EntityFramework.Common;
using AreasMap.Repository.EntityFramework.Context;

namespace AreasMap.Repository.EntityFramework.ShapRepository
{
    public class RectangleBoundsRepository : Repository<RectangleBounds>, IRectangleBoundsRepository
    {
        public RectangleBoundsRepository(AreasMapCoreDbContext context)
            : base(context)
        {
        }
    }
}