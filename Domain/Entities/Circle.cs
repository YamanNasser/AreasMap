using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Circle : Shape
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Radius { get; set; }
    }
}