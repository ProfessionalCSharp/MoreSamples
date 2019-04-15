using System;
using System.Collections.Specialized;

namespace ExplicitInterfaceImplementationSample
{
    public interface IFoo1
    {
        void Foo();
    }

    public class FooImpl1 : IFoo1
    {
        public void Foo() => Console.WriteLine("ImplicitInterfaceImplementation.Foo");
    }

    public class FooImpl2 : IFoo1
    {
        void IFoo1.Foo() => Console.WriteLine("ExplicitInterfaceImplementation.Foo");
    }


    class Program
    {
        static void Main()
        {
            var f2 = new FooImpl2();
            // use a cast
            ((IFoo1)f2).Foo();

            // use the is operator
            if (f2 is IFoo1 f)
            {
                f.Foo();
            }

            // the as operator
            (f2 as IFoo1)?.Foo();

            // invoke a method with IFoo parameter
            DoIt(f2);

            var coll = new MyCollection();
            coll["a"] = "first";
            Console.WriteLine(coll["a"]);

            // Hide interface implementation
            var strings = new StringCollection();
            strings.Add("A string");


        }

        static void DoIt(IFoo1 foo)
        {
            foo.Foo();
        }
    }
}
