using System;

namespace AreasMap.Repository.Core.Models
{
    public class RectangleDto
    {
        public Guid BoundsId { get; set; }
        public RectangleBoundsDto Bounds { get; set; }
    }
}