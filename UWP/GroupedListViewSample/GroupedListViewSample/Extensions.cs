using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupedListViewSample
{
    public static class Extensions
    {
        public static string WeekDay(this DateTime date)
        {
            return date.DayOfWeek.ToString();
        }
    }
}
