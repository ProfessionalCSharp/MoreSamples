using System;

namespace ClassLibrary
{
    public class Sample
    {
        public void Foo()
        {
            Console.WriteLine($"{nameof(ClassLibrary)}.{nameof(Sample)}.{nameof(Foo)}");
        }
    }
}
