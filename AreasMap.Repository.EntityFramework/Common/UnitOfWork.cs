using AreasMap.Repository.Core.Common;
using AreasMap.Repository.Core.Interfaces;
using AreasMap.Repository.EntityFramework.AreasRepository;
using AreasMap.Repository.EntityFramework.Context;
using AreasMap.Repository.EntityFramework.ShapRepository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AreasMap.Repository.EntityFramework.Common
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AreasMapCoreDbContext _context;

        public IAreaRepository AreaRepository { get; private set; }
        public IShapeRepository ShapeRepository { get; private set; }
        public IShapeTypeRepository ShapeTypeRepository { get; private set; }

        public ICircleRepository CircleRepository { get; private set; }
        public ICircleCoordinateRepository CircleCoordinateRepository { get; private set; }

        public IRectangleRepository RectangleRepository { get; private set; }
        public IRectangleBoundsRepository RectangleBoundsRepository { get; private set; }

        public IPolygonRepository PolygonRepository { get; private set; }
        public IPolygonCoordinateRepository PolygonCoordinateRepository { get; private set; }

        public UnitOfWork(AreasMapCoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            AreaRepository = new AreaRepository(_context);
            ShapeRepository = new ShapeRepository(_context);
            ShapeTypeRepository = new ShapeTypeRepository(_context);

            CircleRepository = new CircleRepository(_context);
            CircleCoordinateRepository = new CircleCoordinateRepository(_context);

            RectangleRepository = new RectangleRepository(_context);
            RectangleBoundsRepository = new RectangleBoundsRepository(_context);

            PolygonRepository = new PolygonRepository(_context);
            PolygonCoordinateRepository = new PolygonCoordinateRepository(_context);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return _context.SaveChangesAsync(default);
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}