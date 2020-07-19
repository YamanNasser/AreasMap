using AreasMap.Repository.Core.Common;
using AreasMap.Repository.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;

namespace AreasMap.EF.MSSQL
{
    public class MsSqDbContext : AreasMapCoreDbContext
    {
        public MsSqDbContext(DbContextOptions options, ICurrentUserServiceCore currentUserService)
        : base(options, currentUserService)
        {
        }

        public MsSqDbContext(DbContextOptions options)
          : base(options)
        {
        }
    }
}