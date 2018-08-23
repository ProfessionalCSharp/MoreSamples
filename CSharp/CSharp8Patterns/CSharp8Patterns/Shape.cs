namespace CSharp8Patterns
{
    public abstract class Shape
    {
        public (int x, int y) Position { get; }
        public (int height, int width) Size { get; }
        public Shape((int x, int y) position, (int height, int width) size)
            => (Position, Size) = (position, size);

        public void Deconstruct(out (int x, int y) position, out (int x, int y) size)
            => (position, size) = (Position, Size);

        public string Name => GetType().Name;
    }
}
