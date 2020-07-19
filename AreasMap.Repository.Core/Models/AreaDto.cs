using System;

namespace AreasMap.Repository.Core.Models
{
    public class AreaDto
    {
        public bool Deleted { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ShapeDto Shape { get; set; }
    }
}