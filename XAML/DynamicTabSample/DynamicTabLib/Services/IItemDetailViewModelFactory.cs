using DynamicTabLib.Models;
using DynamicTabLib.ViewModels;
using System.Collections.Generic;

namespace DynamicTabLib.Services
{
    public interface IItemDetailViewModelFactory
    {
        IEnumerable<ItemDetailViewModel> GetItemDetailViewModels(IEnumerable<ItemDetail> itemDetails);
    }
}
