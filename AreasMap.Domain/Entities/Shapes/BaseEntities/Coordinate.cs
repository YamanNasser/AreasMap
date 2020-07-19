using System;

namespace AreasMap.Domain.Entities.Shapes.BaseEntities
{
    public class Coordinate
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}