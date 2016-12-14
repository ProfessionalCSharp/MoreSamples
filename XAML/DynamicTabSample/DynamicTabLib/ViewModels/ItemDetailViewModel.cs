using DynamicTabLib.Framework;
using DynamicTabLib.Models;
using DynamicTabLib.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DynamicTabLib.ViewModels
{
    public class ItemDetailViewModel
    {
        private readonly IOpenItemsDetailService _openItemsDetailService;
        private readonly ItemDetail _itemDetail;

        public ItemDetailViewModel(IOpenItemsDetailService openItemsDetailService)
        {
            _openItemsDetailService = openItemsDetailService;
            CloseCommand = new DelegateCommand(OnClose);
        }
        public ICommand CloseCommand { get; }

        public void OnClose()
        {
            _openItemsDetailService.RemoveItemDetail(this);
        }

        public ItemDetail ItemDetail { get; set; }

    }
}
