using AreasMap.Domain.Entities;
using AreasMap.Domain.Entities.Shapes;
using System.Collections.Generic;

namespace AreasMap.Application.Area.Model
{
    public class AreaMapBulk
    {
        public AreaMapBulk()
        {
            Area = new List<Domain.Entities.Area>();
            Shape = new List<Shape>();
            Circle = new List<Circle>();
            Rectangle = new List<Rectangle>();
            Polygon = new List<Polygon>();
        }

        public List<Domain.Entities.Area> Area { get; set; }
        public List<Shape> Shape { get; set; }
        public List<Circle> Circle { get; set; }
        public List<Rectangle> Rectangle { get; set; }
        public List<Polygon> Polygon { get; set; }
    }
}