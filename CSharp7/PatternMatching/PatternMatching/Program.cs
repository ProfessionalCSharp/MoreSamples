using PatternMatching;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        PatternMatching();
    }

    private static void PatternMatching()
    {
        Console.WriteLine(nameof(PatternMatching));
        object[] data = { null, 42, new Person("Matthias Nagel"), new Person("Katharina Nagel") };

        //foreach (var item in data)
        //{
        //    IsPattern(item);
        //}
        foreach (var item in data)
        {
            SwitchPattern(item);
        }
        Console.WriteLine();
    }

    public static void IsPattern(object o)
    {
        if (o is null) Console.WriteLine("it's a const pattern");

        if (o is 42) Console.WriteLine("it's 42"); // const pattern

        if (o is int i) Console.WriteLine($"it's a type pattern with an int and the value {i}");

        if (o is var x) Console.WriteLine($"it's a var pattern with the type {x?.GetType()?.Name}");

        if (o is Person p) Console.WriteLine($"it's a person: {p.FirstName}");

        if (o is Person p2 && p2.FirstName.StartsWith("Ka")) Console.WriteLine($"it's a person starting with Ka {p2.FirstName}");
    }

    public static void SwitchPattern(object o)
    {
        switch (o)
        {
            case null:
                Console.WriteLine("it's a constant pattern");
                break;
            case int i:
                Console.WriteLine("it's an int");
                break;
            case Person p:
                Console.WriteLine($"any other person {p.FirstName}");
                break;
            case Person p when p.FirstName.StartsWith("Ka"):
                Console.WriteLine($"a Ka person {p.FirstName}");
                break;

            case var x:
                Console.WriteLine($"it's a var pattern with the type {x?.GetType().Name} ");
                break;
            default:
                Console.WriteLine("default");
                break;
        }
    }

    private static void SwitchSample()
    {
        Switch(new Circle { Radius = 10 });
        Switch(new Rectangle { Height = 10, Width = 10 });
        Switch(new Rectangle { Height = 20, Width = 30 });
    }

    private static void Switch(object o)
    {
        switch (o)
        {
            case Circle c:
                Console.WriteLine($"it's a circle with radius {c.Radius}");
                break;
            case Rectangle r when (r.Width == r.Height):
                Console.WriteLine($"it's a square with width {r.Width}");
                break;
            case Rectangle r:
                Console.WriteLine($"it's a rectangle with width {r.Width} and height {r.Height}");
                break;
            default:
                break;
        }
    }

    private static void IsExpressionSample()
    {
        IsExpression(3);
        IsExpression("abc");
    }

    private static void IsExpression(object o)
    {
        if (o is null) throw new ArgumentNullException(nameof(o));  // constant pattern - null
        if (o is int i) // type pattern
        {
            Console.WriteLine($"recevied an int: {i}");
        }
        if (o is string s) // type pattern
        {
            Console.WriteLine($"it's a string {s}");
        }
    }

}