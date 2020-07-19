using System;

namespace AreasMap.Domain.Entities.Shapes
{
    public class PolygonCoordinate
    {
        public Guid Id { get; set; }
        public string CoordinatesAsJson { get; set; }
        public Guid PolygonId { get; set; }
        public Polygon Polygon { get; set; }
    }
}