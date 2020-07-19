using System;

namespace AreasMap.Domain.Entities.Shapes
{
    public class Circle
    {
        public Guid Id { get; set; }
        public double Radius { get; set; }
        public Guid CoordinateId { get; set; }
        public CircleCoordinate Coordinate { get; set; }
    }
}