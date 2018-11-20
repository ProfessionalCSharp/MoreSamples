using System;
using System.ComponentModel.DataAnnotations;

namespace SeedSample
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public string Text { get; set; }
        [DataType(DataType.Date)]
        public DateTime MenuDate { get; set; }
    }
}
