using DynamicTabLib.Models;
using DynamicTabLib.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DynamicTabLib.ViewModels
{
    public class ListViewModel
    {
        private readonly IItemsService _itemsService;
        private readonly IOpenItemsDetailService _openItemsDetailService;
        private readonly IItemDetailViewModelFactory _itemDetailViewModelFactory;
        private readonly ObservableCollection<ItemInfo> _itemInfos;
        public ListViewModel(IItemsService itemsService, IOpenItemsDetailService openItemsDetailService, IItemDetailViewModelFactory itemDetailViewModelFactory)
        {
            _itemsService = itemsService;
            _openItemsDetailService = openItemsDetailService;
            _itemDetailViewModelFactory = itemDetailViewModelFactory;
            _itemInfos = new ObservableCollection<ItemInfo>(itemsService.GetItemInfos());
        }

        public IEnumerable<ItemInfo> Infos => _itemInfos;

        private ItemInfo _currentItemInfo;
        public ItemInfo CurrentItemInfo
        {
            get => _currentItemInfo;
            set
            {
                _currentItemInfo = value;
                _itemsService.CurrentItemInfo = _currentItemInfo;
                _openItemsDetailService.AddItemDetails(_itemDetailViewModelFactory.GetItemDetailViewModels(_currentItemInfo.Details));
            }
        }
    }
}
