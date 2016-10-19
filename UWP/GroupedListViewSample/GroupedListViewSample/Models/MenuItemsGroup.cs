using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace GroupedListViewSample.Models
{
    public class MenuItemsGroup : IGrouping<DateTime, MenuItem>
    {
        private List<MenuItem> _menuItemsGroup;

        public MenuItemsGroup(DateTime key, IEnumerable<MenuItem> items)
        {
            Key = key;
            _menuItemsGroup = new List<MenuItem>(items);
        }

        public DateTime Key { get; }

        public IEnumerator<MenuItem> GetEnumerator() => 
            _menuItemsGroup.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            _menuItemsGroup.GetEnumerator();       
    }
}
