using DynamicTabLib.Models;
using System.Collections.Generic;

namespace DynamicTabLib.Services
{
    public interface IItemsService
    {
        IEnumerable<ItemInfo> GetItemInfos();
    }
}
