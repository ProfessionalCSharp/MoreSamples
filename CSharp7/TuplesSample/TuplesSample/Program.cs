using System;
using System.Collections.Generic;
using System.Linq;

namespace TuplesSample
{
    class Program
    {
        static void Main()
        {
            (int x1, string s1) = (3, "one");
            Console.WriteLine($"{x1} {s1}");

            // declaration before
            int x2;
            string s2;
            (x2, s2) = (42, "two");
            Console.WriteLine($"{x2} {s2}");

            (int result, int reminder) = Divide(11, 3);
            Console.WriteLine($"{result} {reminder}");

            // use the ValueTuple type
            ValueTuple<int, int> tuple1 = Divide(11, 3);
            Console.WriteLine($"{tuple1.Item1} {tuple1.Item2}");

            tuple1.Item1 = 12;

            // tuple literals
            var tuple2 = ("Stephanie", 7);
            Console.WriteLine($"{tuple2.Item1}, {tuple2.Item2}");

            var tuple3 = (Name: "Matthias", Age: 6);
            Console.WriteLine($"{tuple3.Name} {tuple3.Age}");

            // types match
            tuple1 = (result, reminder);
            (int x, int y) = (result, reminder);
            Console.WriteLine($"{x} {y}");

            // use the var keyword
            (var a, var b) = tuple1;
            Console.WriteLine($"{a.GetType().Name} {b.GetType().Name}");

            // use the Deconstruct method
            var p1 = new Person("Katharina", "Nagel");
            (string first, string last) = p1;
            Console.WriteLine($"{first} {last}");

            // use Deconstruct as extension method
            var r1 = new Rectangle(100, 200);
            (int height, int width) = r1;
            Console.WriteLine($"height: {height}, width: {width}");

            // tuple extension method
            (3, 5).Foo();


            ListSample();
        }

        static void ListSample()
        {
            var list = new LinkedList<int>(Enumerable.Range(0, 10));

            int value;
            LinkedListNode<int> node = list.First;
            do
            {
                (value, node) = (node.Value, node.Next);
                Console.WriteLine(value);                 
            } while (node != null);
        }
        

        static (int, int) Divide(int x, int y)
        {
            int result = x / y;
            int reminder = x % y;

            return (result, reminder);
        }
    }

    public static class TupleExtensions
    {
        public static void Foo(this (int x, int y) t)
        {
            Console.WriteLine($"Foo x: {t.x} {t.y}");
        }
    }
}
