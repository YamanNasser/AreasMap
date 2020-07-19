using AreasMap.Domain.Entities;
using AreasMap.Repository.Core.Common;
using AreasMap.Repository.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AreasMap.Repository.Core.Interfaces
{
    public interface IAreaRepository : IRepository<Area>
    {
        Task<List<MainAreaDto>> GetAllAreasAsync();

        Task BulkMergeAsync(AreaMapBulk bulk);
    }
}