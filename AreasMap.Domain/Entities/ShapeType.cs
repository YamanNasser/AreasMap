namespace AreasMap.Domain.Entities
{
    public class ShapeType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public const int Polygon = 1;
        public const int Circle = 2;
        public const int Rectangle = 3;

        public static readonly int[] TypeList = new int[] { Polygon, Circle, Rectangle };
    }
}