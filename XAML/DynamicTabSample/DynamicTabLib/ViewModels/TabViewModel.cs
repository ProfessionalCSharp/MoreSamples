using DynamicTabLib.Framework;
using DynamicTabLib.Services;
using System.Collections.Generic;

namespace DynamicTabLib.ViewModels
{
    public class TabViewModel : BindableBase
    {
        private readonly IOpenItemsDetailService _openItemsDetailService;

        public TabViewModel(IOpenItemsDetailService openItemsDetailService)
        {
            _openItemsDetailService = openItemsDetailService;
            _openItemsDetailService.CurrentItemChanged += (sender, e) =>
            {
                CurrentItem = e.Item;
            };
        }

        public IEnumerable<ItemDetailViewModel> Details => _openItemsDetailService.CurrentItemDetails;

        private ItemDetailViewModel _currentItem;

        public ItemDetailViewModel CurrentItem
        {
            get => _currentItem;
            set => SetProperty(ref _currentItem, value);
        }
    }
}
