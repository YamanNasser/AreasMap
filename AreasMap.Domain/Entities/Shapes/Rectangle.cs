using System;

namespace AreasMap.Domain.Entities.Shapes
{
    public class Rectangle
    {
        public Guid Id { get; set; }
        public Guid BoundsId { get; set; }
        public RectangleBounds Bounds { get; set; }
    }
}