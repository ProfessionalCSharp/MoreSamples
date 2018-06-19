namespace CSharp8Patterns
{
    public class CombinedShape : Shape
    {
        public Shape Shape1 { get; }
        public Shape Shape2 { get; }
        public CombinedShape(Shape shape1, Shape shape2)
            : base(position: shape1.Position, size: GetCombinedSize(shape1, shape2))
            => (Shape1, Shape2) = (shape1, shape2);

        public void Deconstruct(out Shape shape1, out Shape shape2)
            => (shape1, shape2) = (Shape1, Shape2);

        private static (int, int) GetCombinedSize(Shape shape1, Shape shape2)
        {
            int combinedHeight = 0;
            int combinedWidth = 0;
            if ((shape1.Position.y + shape1.Size.height) > shape2.Position.y)
            {
                int delta = shape1.Position.y + shape1.Size.height - shape2.Position.y;
                combinedHeight = shape1.Size.height + shape2.Size.height - delta;
            }
            else
            {
                int delta = shape2.Position.y - (shape1.Position.y + shape1.Size.height);
                combinedHeight = shape1.Size.height + shape2.Size.height + delta;
            }
            if ((shape2.Position.x + shape2.Size.width) > shape2.Position.x)
            {
                int delta = shape1.Position.x + shape1.Size.width - shape2.Position.x;
                combinedWidth = shape1.Size.width + shape2.Size.width - delta;
            }
            else
            {
                int delta = shape2.Position.x - (shape1.Position.y + shape1.Size.width);
                combinedWidth = shape1.Size.width + shape2.Size.width + delta;
            }

            return (combinedHeight, combinedWidth);
        }


    }
}
