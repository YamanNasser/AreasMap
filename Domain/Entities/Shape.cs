using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Domain.Entities
{
    public class Shape
    {
        //some of common properties
        public Guid Id { get; set; }

        public Color Color { get; set; }
        public double Opacity { get; set; }
        public int Weight { get; set; }
    }
}