using System;

namespace CSharp8Patterns
{
    class Program
    {
        static void Main()
        {
            var r1 = new Rectangle(position: (200, 200), size: (200, 200));
            var e1 = new Ellipse(position: (80, 1400), size: (80, 140));
            var shapes = new Shape[]
            {
                r1,
                e1,
                new Circle((40, 60), 90),
                new CombinedShape(r1, e1)
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine(M1(shape));
            }
        }

        static string M1(Shape shape)
        {
            switch (shape)
            {
                case Shape s when s.Size.height > 100:
                    return $"large shape with size {s.Size} at position {s.Position}";
                case Ellipse e:
                    return $"Ellipse with size {e.Size} at position {e.Position}";
                case Rectangle r:
                    return $"Rectangle with size {r.Size} at position {r.Position}";
                default:
                    return "another shape";                    
            }
        }

        static string M2(Shape shape)
            => shape switch
            {
                Shape s when s.Size.height > 100 => $"large shape with size {s.Size} at position {s.Position}",
                Ellipse e => $"Ellipse with size {e.Size} at position {e.Position}",
                Rectangle r => $"Rectangle with size {r.Size} at position {r.Position}",
                _ => "another shape"
            };

        static string M3(Shape shape)
            => shape switch
        {
            CombinedShape (var shape1, var (pos, _)) => $"combined shape - shape1: {shape1.Name}, pos of shape2: {pos}",
            { Size: (200, 200), Position: var pos } => $"shape with size 200x200 at position {pos.x}:{pos.y}",
            Ellipse (var pos, var size) => $"Ellipse with size {size} at position {pos}",
            Rectangle (_, var size) => $"Rectangle with size {size}",
            _ => "another shape"
        };
    }
}
