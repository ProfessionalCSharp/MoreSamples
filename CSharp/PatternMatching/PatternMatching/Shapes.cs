using System;
using System.Collections.Generic;
using System.Text;

namespace PatternMatching
{
    public abstract class Shape
    {
    }

    public class Circle : Shape
    {
        public double Radius { get; set; }
    }
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
