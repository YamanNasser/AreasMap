using AreasMap.Domain.Common;
using AreasMap.Domain.Entities;
using AreasMap.Domain.Entities.Shapes;
using AreasMap.Repository.Core.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AreasMap.Repository.EntityFramework.Context
{
    public class AreasMapCoreDbContext : DbContext
    {
        private readonly ICurrentUserServiceCore _currentUserService;

        public AreasMapCoreDbContext(DbContextOptions options, ICurrentUserServiceCore currentUserService)
         : base(options)
        {
            _currentUserService = currentUserService;
        }

        public AreasMapCoreDbContext(DbContextOptions options)
          : base(options)
        {
        }

        protected AreasMapCoreDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AreasMapCoreDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Area> Area { get; set; }

        public DbSet<Shape> Shape { get; set; }
        public DbSet<ShapeType> ShapeType { get; set; }

        public DbSet<Rectangle> Rectangle { get; set; }
        public DbSet<RectangleBounds> RectangleBounds { get; set; }

        public DbSet<Polygon> Polygon { get; set; }
        public DbSet<PolygonCoordinate> PolygonCoordinate { get; set; }

        public DbSet<Circle> Circle { get; set; }
        public DbSet<CircleCoordinate> CircleCoordinate { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (_currentUserService?.UserId != null)
                            entry.Entity.CreatedBy = _currentUserService?.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        if (_currentUserService?.UserId != null)
                            entry.Entity.LastModifiedBy = _currentUserService?.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService?.UserId;
                        entry.Entity.Created = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedBy = _currentUserService?.UserId;
                        entry.Entity.LastModified = DateTime.Now;
                        break;
                }
            }

            return base.SaveChanges();
        }
    }
}