using System;
using System.Collections.Generic;

namespace AreasMap.Repository.Core.Models
{
    public class PolygonDto
    {
        public Guid CoordinateId { get; set; }
        public List<PolygonCoordinateDto> Coordinate { get; set; }
    }
}