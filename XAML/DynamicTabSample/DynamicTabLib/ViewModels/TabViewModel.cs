using DynamicTabLib.Framework;
using DynamicTabLib.Models;
using DynamicTabLib.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace DynamicTabLib.ViewModels
{

    public class TabViewModel : BindableBase
    {
        private readonly IItemsService _itemsService;
        private readonly IOpenItemsDetailService _openItemsDetailService;
        private readonly ObservableCollection<ItemDetailViewModel> _itemDetails = new ObservableCollection<ItemDetailViewModel>();

        public TabViewModel(IItemsService itemsService, IOpenItemsDetailService openItemsDetailService)
        {
            _itemsService = itemsService;
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
            get { return _currentItem; }
            set { SetProperty(ref _currentItem, value); }
        }

    }
}
