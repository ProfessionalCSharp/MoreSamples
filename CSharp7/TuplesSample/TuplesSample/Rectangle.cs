using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuplesSample
{
    public class Rectangle
    {
        public Rectangle(int height, int width)
        {
            Height = height;
            Width = width;
        }

        public int Width { get; }
        public int Height { get; }
    }

    public static class RectangleExtensions
    {
        public static void Deconstruct(this Rectangle rectangle, out int height, out int width)
        {
            height = rectangle.Height;
            width = rectangle.Width;
        }
    }
}
