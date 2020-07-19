using AreasMap.Domain.Entities.Shapes.BaseEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AreasMap.Repository.Core.Models
{
    public class ShapeCoreDto
    {
        public int Type { get; set; }
        public Guid Id { get; set; }
        public dynamic Data { get; set; }
    }
}