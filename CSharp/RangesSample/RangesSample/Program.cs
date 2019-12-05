using System;
using System.Collections.Generic;
using System.Linq;

namespace RangesSample
{
    public static class ListExtensions
    {
        public static IEnumerable<T> Slice<T>(this List<T> list, int begin, int count)
        {
            return list.GetRange(begin, count);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //TheHatOperator();
            //RangeWithStrings();

            RangesWithSpans();
            RangesWithArrays();
            //RangesWithLists();
            //RangesWithCustomCollections();
        }

        private static void TheHatOperator()
        {
            Console.WriteLine(nameof(TheHatOperator));
            var last = ^1;
            Console.WriteLine($"the type of ^1 is : {last.GetType().Name}");
            int[] arr = { 1, 2, 3 };
            int lastItem = arr[last];
            Console.WriteLine(lastItem);

            int lastItem2 = arr[arr.Length - 1];
            Console.WriteLine(lastItem2);
            Console.WriteLine();
        }

        private static void RangeWithStrings()
        {
            Console.WriteLine(nameof(RangeWithStrings));
            string text1 = "the quick brown fox jumped over the lazy dogs";
            string lazyDogs1 = text1.Substring(36, 9); // lazy dogs

            string lazyDogs2 = text1.Substring(text1.Length - 9, 9); // lazy dogs

            string lazyDogs3 = text1[^9..^0]; // lazy dogs
            var start = ^9;
            var end = ^0;
            var range = new Range(start, end);

            var r = 3..5;


            string lazyDogs4 = text1[^9..];  // Range.FromStart

            string lazyDogs5 = text1[36..]; // Range.FromStart

            string thequick = text1[..9]; // Range.ToEnd

            string completeString = text1[..]; // Range.All
            Console.WriteLine();
        }

        private static void RangesWithCustomCollections()
        {
            Console.WriteLine(nameof(RangesWithCustomCollections));
            var list = Enumerable.Range(1, 100)
                .Select(x => new SomeData($"text {x}")).ToArray();
            var coll = new CustomCollection<SomeData>(list);
            var range = coll[10..20];
            //foreach (var item in range)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine();

            

        }

        private static void RangesWithLists()
        {
            var list = Enumerable.Range(1, 100)
                .Select(x => new SomeData($"text {x}")).ToList();

            var item = list[^10];
            Console.WriteLine(item);

            // var range = list[20..25];


        }

        private static void RangesWithSpans()
        {
            var span1 = new[] { 1, 4, 8, 11, 19, 31 }.AsSpan();
            var range = span1[2..5];  // from inclusive to exclusive - 8, 11, 19
            ref int elt = ref range[^1]; // 19
            elt = 42;
            int copiedelement = range[^1];
            Console.WriteLine($"change value {copiedelement} to 11");
            copiedelement = 11;
            Console.WriteLine($"the original element is changed: {span1[4]}");
        }

        private static void RangesWithArrays()
        {
            var arr = new[] { 1, 4, 8, 11, 19, 31 };
            var range = arr[2..5];
            ref int elt = ref range[^1];
            elt = 42;
            int copiedelement = range[^1];
            Console.WriteLine($"change value {copiedelement} to 11");
            copiedelement = 11;
            Console.WriteLine($"the original element is not changed: {arr[4]}");
        }




    }
}
