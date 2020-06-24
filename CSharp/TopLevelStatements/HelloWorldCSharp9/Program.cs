using System;

Console.WriteLine("Hello World!");

if (args.Length > 0)
{
    foreach (var arg in args)
    {
        Console.WriteLine(arg);
    }
}

Foo();

int x = 3;

int result = AddToX(4);
Console.WriteLine(result);

static void Foo()
{
    Console.WriteLine("Foo");
}

int AddToX(int y)
{
    return x + y;
}



