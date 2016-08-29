using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupedListViewSample.Models
{
    // Issue with current UWP: inherited interfaces are not recognized
    // https://connect.microsoft.com/VisualStudio/feedback/details/1770944/uwp-xaml-x-bind-inherited-interfaces-are-not-recognized
    public interface IGroupedMenuItems : IGrouping<DateTime, MenuItem>
    {
    }

}
