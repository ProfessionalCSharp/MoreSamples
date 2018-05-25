using System;

// Expression Bodied Members Sample

class Resource : IDisposable
{
    // C# 7.0 - Constructor
    public Resource() => Console.WriteLine($"ctor {nameof(Resource)}");

    // C# 7.0 - Destructor
    ~Resource() => Console.WriteLine("Destructor");

    // C# 6.0 - Method
    public int UltimateAnswer() => 42;

    // C# 6 - Get-accessor only Property
    public int Y => 42;

    public void Dispose() => Console.WriteLine("Disposing");

    protected void Dispose(bool disposing)
    {
        if (disposing == true)
        {
            Dispose();
            GC.SuppressFinalize(this);
        }
    }

    private int _x;

    // C# 7.0 - Property Accessors
    public int X
    {
        get => _x;
        set => _x = value;
    }

}

class Program
{
    static void Main()
    {
        using (var r = new Resource())
        {
            r.X = 3;
            Console.WriteLine(r.X);
        }
    }
}