using System;

namespace AreasMap.Domain.Entities
{
    public class Shape
    {
        public Guid Id { get; set; }
        public int TypeId { get; set; }
        public ShapeType Type { get; set; }
        public Guid AreaId { get; set; }
        public Area Area { get; set; }
        public string DataAsJson { get; set; }
    }
}