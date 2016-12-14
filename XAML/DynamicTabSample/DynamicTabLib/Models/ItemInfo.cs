using System.Collections.Generic;

namespace DynamicTabLib.Models
{
    public class ItemInfo
    {
        public int ItemId { get; set; }
        public string Title { get; set; }
        public IEnumerable<ItemDetail> Details { get; set; }
    }
}
