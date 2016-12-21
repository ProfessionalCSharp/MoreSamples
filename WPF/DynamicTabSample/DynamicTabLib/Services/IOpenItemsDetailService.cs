using DynamicTabLib.ViewModels;
using System;
using System.Collections.Generic;

namespace DynamicTabLib.Services
{
    public class ItemDetailViewModelEventArgs : EventArgs
    {
        public ItemDetailViewModel Item { get; set; }
    }

    public interface IOpenItemsDetailService
    {
        event EventHandler<ItemDetailViewModelEventArgs> CurrentItemChanged;
        IEnumerable<ItemDetailViewModel> CurrentItemDetails { get; }
        void AddItemDetails(IEnumerable<ItemDetailViewModel> details);
        void RemoveItemDetail(ItemDetailViewModel detail);
    }
}
