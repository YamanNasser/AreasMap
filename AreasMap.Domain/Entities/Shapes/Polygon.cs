using System;

namespace AreasMap.Domain.Entities.Shapes
{
    public class Polygon
    {
        public Guid Id { get; set; }
        public Guid CoordinateId { get; set; }
        public PolygonCoordinate Coordinate { get; set; }
    }
}