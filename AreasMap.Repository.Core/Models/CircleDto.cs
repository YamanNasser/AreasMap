using System;

namespace AreasMap.Repository.Core.Models
{
    public class CircleDto
    {
        public Guid CoordinateId { get; set; }

        public double Radius { get; set; }
        public CoordinateDto Coordinate { get; set; }
    }
}