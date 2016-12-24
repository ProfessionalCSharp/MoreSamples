using DynamicTabLib.Models;
using DynamicTabLib.Services;
using DynamicTabLib.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WPFDynamicTabSample.Services
{
    public class ItemDetailViewModelFactory : IItemDetailViewModelFactory
    {
        private readonly IOpenItemsDetailService _openItemsDetailService;
        public ItemDetailViewModelFactory(IOpenItemsDetailService openItemsDetailService)
        {
            _openItemsDetailService = openItemsDetailService;
        }
        public IEnumerable<ItemDetailViewModel> GetItemDetailViewModels(IEnumerable<ItemDetail> itemDetails)
        {
            IEnumerable<ItemDetail> openedItemDetails = _openItemsDetailService.CurrentItemDetails.Select(vm => vm.ItemDetail);
            foreach (var itemDetail in itemDetails)
            {
                if (!openedItemDetails.Contains(itemDetail)) // don't create itemdetailviewmodels if the item is already in the existing list
                {
                    ItemDetailViewModel itemDetailViewModel = (Application.Current as App).Container.GetService<ItemDetailViewModel>();
                    itemDetailViewModel.ItemDetail = itemDetail;
                    yield return itemDetailViewModel;
                }
            }
        }
    }
}
