using AreasMap.Domain.Entities.Shapes.BaseEntities;

namespace AreasMap.Repository.Core.Models
{
    public class GeneralShapeData
    {
        public CoordinateDto Coordinate { get; set; }
        public double Radius { get; set; }
        public Bounds Bounds { get; set; }
        public string CoordinatesAsJson { get; set; }
    }
}