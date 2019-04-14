using System;

namespace UsingDeclarationSample
{
    public class AResource : IDisposable
    {
        public void UseIt() => Console.WriteLine($"{nameof(UseIt)}");
        public void Dispose() => Console.WriteLine($"Dispose {nameof(AResource)}");
    }
}
