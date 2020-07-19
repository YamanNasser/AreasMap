using System;

namespace AreasMap.Repository.Core.Models
{
    public class ShapeDto
    {
        public Guid Id { get; set; }
        public int Type { get; set; }
        public dynamic Data { get; set; }
    }
}