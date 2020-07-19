using AreasMap.Repository.Core.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AreasMap.Repository.Core.Common
{
    public interface IUnitOfWork : IDisposable
    {
        IAreaRepository AreaRepository { get; }

        IShapeRepository ShapeRepository { get; }
        IShapeTypeRepository ShapeTypeRepository { get; }

        ICircleRepository CircleRepository { get; }
        ICircleCoordinateRepository CircleCoordinateRepository { get; }

        IPolygonRepository PolygonRepository { get; }
        IPolygonCoordinateRepository PolygonCoordinateRepository { get; }

        IRectangleRepository RectangleRepository { get; }
        IRectangleBoundsRepository RectangleBoundsRepository { get; }

        void BeginBulkTransaction();

        int Commit();

        Task<int> CommitAsync(CancellationToken cancellationToken);

        Task<int> CommitAsync();

        Task CommitBulkAsync();

        Task RollBulkbackAsync();
    }
}