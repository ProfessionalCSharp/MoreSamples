using System;
using System.Collections.Generic;
using System.Text;

namespace RangesSample
{
    public class CustomCollection<T>
    {
        private readonly List<T> _items = new List<T>();
        public CustomCollection(params T[] items)
        {
            _items.AddRange(items);
        }

        public int Count => _items.Count;

        //public IEnumerable<T> Slice(int begin, int length)
        //{
        //    for (int i = 0; i < length; i++)
        //    {
        //        yield return _items[begin + i];
        //    }
        //}

        public CustomCollection<T> Slice(int begin, int count)
        {
            var slice = _items.GetRange(begin, count).ToArray();
            return new CustomCollection<T>(slice);
        }
    }
}
