using AreasMap.Domain.Common;
using System;

namespace AreasMap.Domain.Entities
{
    public class Area : AuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ShapeId { get; set; }
        public Shape Shape { get; set; }
    }
}