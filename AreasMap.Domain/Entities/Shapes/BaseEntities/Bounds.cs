using System;

namespace AreasMap.Domain.Entities.Shapes.BaseEntities
{
    public class Bounds
    {
        public Guid Id { get; set; }
        public double North { get; set; }
        public double South { get; set; }
        public double East { get; set; }
        public double West { get; set; }
    }
}