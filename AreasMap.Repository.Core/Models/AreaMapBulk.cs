using AreasMap.Domain.Entities;
using AreasMap.Domain.Entities.Shapes;
using System.Collections.Generic;

namespace AreasMap.Repository.Core.Models
{
    public class AreaMapBulk
    {
        public AreaMapBulk()
        {
            Area = new List<Area>();
            Shape = new List<Shape>();
            Circle = new List<Circle>();
            Rectangle = new List<Rectangle>();
            Polygon = new List<Polygon>();
        }

        public List<Area> Area { get; set; }
        public List<Shape> Shape { get; set; }
        public List<Circle> Circle { get; set; }
        public List<Rectangle> Rectangle { get; set; }
        public List<Polygon> Polygon { get; set; }
    }
}