using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupedListViewSample.Models
{
    public class MenuItem : BindableBase
    {
        public int MenuItemId { get; set; }

        private DateTime _day;
        public DateTime Day
        {
            get { return _day; }
            set { SetProperty(ref _day, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

    }
}
