using AreasMap.Domain.Entities.Shapes;
using AreasMap.Repository.Core.Interfaces;
using AreasMap.Repository.EntityFramework.Common;
using AreasMap.Repository.EntityFramework.Context;

namespace AreasMap.Repository.EntityFramework.ShapRepository
{
    public class CircleRepository : Repository<Circle>, ICircleRepository
    {
        public CircleRepository(AreasMapCoreDbContext context)
            : base(context)
        {
        }
    }
}