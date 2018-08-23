namespace CSharp8Patterns
{
    public class Ellipse : Shape
    {
        public Ellipse((int x, int y) position, (int height, int width) size)
            : base(position, size)
        {
        }
    }

    public class Rectangle : Shape
    {
        public Rectangle((int x, int y) position, (int height, int width) size)
            : base(position, size)
        {
        }
    }

    public class Circle : Ellipse
    {
        public Circle((int x, int y) position, int size)
            : base(position, (size, size))
        { }
    }
}
