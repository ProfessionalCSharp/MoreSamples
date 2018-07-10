using System;

namespace RangesSample
{
    class Program
    {
        static void Main(string[] args)
        {
            TheHatOperator();
            RangeWithStrings();
            RangesWithArrays();
        }

        private static void RangesWithArrays()
        {
            var arr = new[] { 1, 4, 8, 11, 19, 31 };
            var range = arr[2..5];
            ref int elt = ref range[1];
            elt = 42;
            int copiedelement = range[1];
            copiedelement = 11;
            Console.WriteLine($"the original element is changed: {arr[3]}");
        }

        private static void TheHatOperator()
        {
            var last = ^1;
            int[] arr = { 1, 2, 3 };
            int lastItem = arr[last];
            Console.WriteLine(lastItem);

            int lastItem2 = arr[arr.Length - 1];
            Console.WriteLine(lastItem2);
        }

        private static void RangeWithStrings()
        {
            string text1 = "the quick brown fox jumped over the lazy dogs";
            string lazyDogs1 = text1.Substring(36, 9);

            string lazyDogs2 = text1.Substring(text1.Length - 9, 9);

            string lazyDogs3 = text1[^9..^0];
            var start = ^9;
            var end = ^0;
            var range = Range.Create(start, end);
            string lazyDogs4 = text1.Substring(range);

            string lazyDogs5 = text1[^9..];  // Range.FromStart

            string lazyDogs6 = text1[36..]; // Range.FromStart

            string thequick = text1[..9]; // Range.ToEnd

            string completeString = text1[..]; // Range.All
        }
    }
}
