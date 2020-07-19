using System;

namespace AreasMap.Repository.Core.Models
{
    public class MainAreaDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ShapeDto Shape { get; set; }
    }
}