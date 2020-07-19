using AreasMap.Domain.Entities.Shapes.BaseEntities;
using System;

namespace AreasMap.Domain.Entities.Shapes
{
    public class CircleCoordinate : Coordinate
    {
        public Guid CircleId { get; set; }
        public Circle Circle { get; set; }
    }
}