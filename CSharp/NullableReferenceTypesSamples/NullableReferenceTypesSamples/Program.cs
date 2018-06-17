using NewAndGloryLib;
using TheOldLib;

namespace NullableReferenceTypesSamples
{
    class SomeClass : ILegacyInterface
    {
        public string? Foo() => null;
    }

    class AnotherClass : ILegacyInterface
    {
        public string Foo() => "a string";
    }

    class SomeClass1 : INewInterface
    {
        public string Bar() => "a string";
    }

    class Program
    {
        static void Main()
        {
            var book = new Book("Professional C# 8", "Wrox Press");
            // string isbn = book.Isbn;  // error: converting null literal or possible null value to non-nullable type
            string? isbn = book.Isbn;

            var newglory = new NewAndGlory();
            string? s1 = newglory.GetANullString();
            string s2 = newglory.GetAString();
            // string s3 = newglory.PassAString(null); // error: cannot convert null literal to non-nullable reference or unconstrained type parameter

            var old = new Legacy();
            string s4 = old.GetANullString();  // no error, s1 is null!
            string s5 = old.PassAString(null); // no error


          
            var sc = new SomeClass();
            string? s6 = sc.Foo();
            string s7 = sc.Foo()!;  // dammit

        }

        static string GetIsbn1(Book book)
        {
            string? isbn = book.Isbn;
            if (isbn == null)
            {
                return string.Empty;
            }
            return isbn;
        }

        public string GetIsbn2(Book book)
            => book.Isbn ?? string.Empty;
    }
}
