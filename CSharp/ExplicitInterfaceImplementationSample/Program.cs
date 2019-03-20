using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ExplicitInterfaceImplementationSample
{
    public interface IFoo
    {
        void Foo();
    }

    public class Foo1 : IFoo
    {
        void IFoo.Foo() => Console.WriteLine("IFoo.Foo");
    }

    public interface IFoo2
    {
        void Foo();
    }

    public class Foo2 : IFoo, IFoo2
    {
        public void Foo() => Console.WriteLine("Foo2.Foo");
        void IFoo.Foo() => Console.WriteLine("IFoo.Foo");
    }

    public class MyCollection : IDataErrorInfo
    {
        private Dictionary<string, string> _data = new Dictionary<string, string>();

        public string this[string columnName] => throw new NotImplementedException();

        public string Error => throw new NotImplementedException();
    }

    class Program
    {
        static void Main()
        {
            var f1 = new Foo1();

            (f1 as IFoo)?.Foo();

            if (f1 is IFoo f)
            {
                f.Foo();
            }

            var strings = new StringCollection();

            strings.Add()

        }
    }
}
