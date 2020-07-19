using AreasMap.EF.Common.Extensions;
using AreasMap.Repository.EntityFramework.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AreasMap.EF.MSSQL
{
    public static class MsSqlConfigureEfContainerExtentions
    {
        public static void AddMsSqlInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            var builder = new DbContextOptionsBuilder<MsSqDbContext>();
            builder.UseSqlServer(
                config.GetConnectionString("MsSqDbContext"));

            services.AddScoped<AreasMapCoreDbContext>(db => new MsSqDbContext(builder.Options));

            services.AddInfrastructure();
        }
    }
}