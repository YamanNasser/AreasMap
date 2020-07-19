using AreasMap.Domain.Entities.Shapes;
using AreasMap.Repository.Core.Interfaces;
using AreasMap.Repository.EntityFramework.Common;
using AreasMap.Repository.EntityFramework.Context;

namespace AreasMap.Repository.EntityFramework.ShapRepository
{
    public class RectangleRepository : Repository<Rectangle>, IRectangleRepository
    {
        public RectangleRepository(AreasMapCoreDbContext context)
            : base(context)
        {
        }
    }
}