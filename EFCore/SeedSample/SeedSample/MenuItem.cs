using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
