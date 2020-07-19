using AreasMap.Repository.Core.Common;
using AreasMap.Repository.Core.Interfaces;
using AreasMap.Repository.EntityFramework.AreasRepository;
using AreasMap.Repository.EntityFramework.Common;
using AreasMap.Repository.EntityFramework.ShapRepository;
using Microsoft.Extensions.DependencyInjection;

namespace AreasMap.EF.Common.Extensions
{
    public static class ConfigureEfContainerExtentions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IAreaRepository, AreaRepository>();

            services.AddTransient<IShapeRepository, ShapeRepository>();
            services.AddTransient<IShapeTypeRepository, ShapeTypeRepository>();

            services.AddTransient<ICircleRepository, CircleRepository>();
            services.AddTransient<ICircleCoordinateRepository, CircleCoordinateRepository>();

            services.AddTransient<IPolygonRepository, PolygonRepository>();
            services.AddTransient<IPolygonCoordinateRepository, PolygonCoordinateRepository>();

            services.AddTransient<IRectangleRepository, RectangleRepository>();
            services.AddTransient<IRectangleBoundsRepository, RectangleBoundsRepository>();
        }
    }
}