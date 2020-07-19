using AreasMap.Domain.Entities.Shapes.BaseEntities;
using System;

namespace AreasMap.Domain.Entities.Shapes
{
    public class RectangleBounds : Bounds
    {
        public Guid RectangleId { get; set; }
        public Rectangle Rectangle { get; set; }
    }
}