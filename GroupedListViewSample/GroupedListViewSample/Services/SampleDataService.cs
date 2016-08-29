using GroupedListViewSample.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupedListViewSample.Services
{
    public class SampleDataService : IDataService
    {
        private readonly List<MenuItem> _data;
        public SampleDataService()
        {
            DateTime today = DateTime.Today;
            var menus = Enumerable.Range(0, 14)
                .Select(i =>
                    new MenuItem()
                    {
                        MenuItemId = i,
                        Title = $"Sample Menu {i}",
                        Day = today.AddDays(i / 2)
                    });
            _data = new List<MenuItem>(menus);
        }

        public IEnumerable<MenuItem> GetMenus() => _data;
    }
}
