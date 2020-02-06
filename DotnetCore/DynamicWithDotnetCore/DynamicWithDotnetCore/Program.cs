using System;
using System.Reflection;

namespace DynamicWithDotnetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args == null || string.IsNullOrEmpty(args[0]))
            {
                Console.WriteLine($"add a path to the lib");
                return;
            }
            var assembly = Assembly.LoadFile(args[0]);
            var type = assembly.GetType("JustALib.Calculator");
            object calc = Activator.CreateInstance(type);

            UseReflection(calc);
            UseDynamic(calc);
        }

        private static void UseReflection(object calc)
        {
            var method = calc.GetType().GetMethod("Add");
            var result = method.Invoke(calc, new object[] { 34, 8 });
            Console.WriteLine(result);
        }

        private static void UseDynamic(dynamic calc)
        {
            var result = calc.Add(34, 8);
            Console.WriteLine(result);
        }
    }
}
