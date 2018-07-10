using System;

namespace Wrox.ProCSharp.Assemblies
{
    class Program
    {
        static void Main()
        {
            var quotes = new SharedDemo("Quotes.txt");
            Console.WriteLine(quotes.FullName);
            //for (int i = 0; i < 3; i++)
            //{
            //    Console.WriteLine(quotes.GetQuoteOfTheDay());
            //    Console.WriteLine();
            //}

        }
    }
}
