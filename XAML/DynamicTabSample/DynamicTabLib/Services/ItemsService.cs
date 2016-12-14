using DynamicTabLib.Framework;
using DynamicTabLib.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DynamicTabLib.Services
{
    public class ItemsService : BindableBase, IItemsService
    {
        private readonly List<ItemInfo> _itemInfos;
        private readonly ObservableCollection<ItemDetail> _currentDetails = new ObservableCollection<ItemDetail>();

        public ItemsService()
        {
            var random = new Random();
            _itemInfos = Enumerable.Range(1, 1000)
                .Select(x => new ItemInfo
                {
                    ItemId = x,
                    Title = $"title {x}",
                    Details = Enumerable.Range(1, random.Next(1, 3)).Select(x1 => new ItemDetail
                    {
                        ItemDetailId = Guid.NewGuid().ToString(),
                        Title = $"{x} detail {x1}"
                    }).ToList()
                })
                .ToList();
        }

        public IEnumerable<ItemInfo> GetItemInfos() => _itemInfos;

        public IEnumerable<ItemDetail> CurrentDetails => _currentDetails;

        private ItemInfo _currentItemInfo;
        public ItemInfo CurrentItemInfo
        {
            get { return _currentItemInfo; }
            set
            {
                if (SetProperty(ref _currentItemInfo, value))
                {
                    foreach (var detail in _currentItemInfo.Details)
                    {
                        _currentDetails.Add(detail);
                    }
                }
            }
        }
    }
}
