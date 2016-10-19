using GroupedListViewSample.Models;
using GroupedListViewSample.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GroupedListViewSample.ViewModels
{
    public class MainPageViewModel
    {
        private readonly IDataService _dataService;

        public MainPageViewModel(IDataService dataService)
        {
            _dataService = dataService;
            GetData();
        }

        private void GetData()
        {
            var menus = _dataService.GetMenus();
            GroupedMenuItems =
                menus.GroupBy(m => m.Day, (key, list) => new MenuItemsGroup(key, list));
        }

        public IEnumerable<MenuItemsGroup> GroupedMenuItems { get; private set; }
    }
}
