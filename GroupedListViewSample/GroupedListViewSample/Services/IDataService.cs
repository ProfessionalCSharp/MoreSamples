using System.Collections.Generic;
using GroupedListViewSample.Models;

namespace GroupedListViewSample.Services
{
    public interface IDataService
    {
        IEnumerable<MenuItem> GetMenus();
    }
}