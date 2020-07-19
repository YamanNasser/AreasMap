using AreasMap.Application.Area.Commands.Create;
using AreasMap.Domain.Entities;
using AreasMap.Domain.Entities.Shapes;
using AreasMap.Repository.Core.Common;
using AreasMap.Repository.Core.Models;
using MediatR;
using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AreasMap.Application.Area.Handlers.Commands.Create
{
    public class CreateListOfAreasCommandHandler : IRequestHandler<CreateListOfAreasCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateListOfAreasCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CreateListOfAreasCommand request, CancellationToken cancellationToken)
        {
            var bulk = new AreaMapBulk();

            foreach (var area in request.Areas)
            {
                var areaId = Guid.NewGuid();
                var shapId = Guid.NewGuid();
                string data = area.Shape.Data.ToString();

                AddArea(area, areaId, shapId, bulk);
                AddShape(area, areaId, shapId, bulk);

                switch (area.Shape.Type)
                {
                    case ShapeType.Circle:
                        {
                            AddCircle(shapId, data, bulk);
                        }
                        break;

                    case ShapeType.Rectangle:
                        {
                            AddRectangle(shapId, data, bulk);
                        }
                        break;

                    case ShapeType.Polygon:
                        {
                            AddPolygon(shapId, data, bulk);
                        }
                        break;
                }
            }

            return await _unitOfWork.AreaRepository.BulkMergeAsync(bulk);
        }

        private void AddArea(MainAreaDto area, Guid areaId, Guid shapId, AreaMapBulk bulk)
        {
            bulk.Area.Add(
                new Domain.Entities.Area()
                {
                    Id = areaId,
                    Name = area.Name,
                    ShapeId = shapId
                });
        }

        private void AddShape(MainAreaDto area, Guid areaId, Guid shapId, AreaMapBulk bulk)
        {
            bulk.Shape.Add(new Shape()
            {
                Id = shapId,
                TypeId = area.Shape.Type,
                AreaId = areaId
            });
        }

        private void AddPolygon(Guid shapId, string data, AreaMapBulk bulk)
        {
            var polygon = JsonSerializer.Deserialize<PolygonDto>(data);
            var coordinateId = Guid.NewGuid();
            bulk.Polygon.Add(
                new Polygon
                {
                    Id = shapId,
                    CoordinateId = coordinateId,
                    Coordinate = new PolygonCoordinate()
                    {
                        CoordinatesAsJson = JsonSerializer.Serialize(polygon.Coordinate),
                        PolygonId = shapId,
                        Id = coordinateId
                    }
                });
        }

        private void AddRectangle(Guid shapId, string data, AreaMapBulk bulk)
        {
            var rectangle = JsonSerializer.Deserialize<RectangleDto>(data);
            var boundsId = Guid.NewGuid();
            bulk.Rectangle.Add(
                new Rectangle()
                {
                    Id = shapId,
                    BoundsId = boundsId,
                    Bounds = new RectangleBounds()
                    {
                        RectangleId = shapId,
                        East = rectangle.Bounds.East,
                        North = rectangle.Bounds.North,
                        South = rectangle.Bounds.South,
                        West = rectangle.Bounds.West,
                        Id = boundsId
                    }
                });
        }

        private void AddCircle(Guid shapId, string data, AreaMapBulk bulk)
        {
            var circle = JsonSerializer.Deserialize<CircleDto>(data);
            var coordinateId = Guid.NewGuid();
            bulk.Circle.Add(new Circle()
            {
                Id = shapId,
                Radius = circle.Radius,
                CoordinateId = coordinateId,
                Coordinate = new CircleCoordinate()
                {
                    Latitude = circle.Coordinate.Latitude,
                    Longitude = circle.Coordinate.Longitude,
                    Id = Guid.NewGuid(),
                    CircleId = shapId
                }
            });
        }
    }
}