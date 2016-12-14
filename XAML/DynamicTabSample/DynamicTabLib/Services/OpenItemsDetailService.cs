using DynamicTabLib.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DynamicTabLib.Services
{

    public class OpenItemsDetailService : IOpenItemsDetailService
    {
        public event EventHandler<ItemDetailViewModelEventArgs> CurrentItemChanged;

        private ObservableCollection<ItemDetailViewModel> _currentItemDetails = new ObservableCollection<ItemDetailViewModel>();
        public IEnumerable<ItemDetailViewModel> CurrentItemDetails => _currentItemDetails;

        public void AddItemDetails(IEnumerable<ItemDetailViewModel> details)
        {
            if (details == null) throw new ArgumentNullException(nameof(details));

            foreach (var detail in details)
            {
                if (!_currentItemDetails.Contains(detail))
                {
                    _currentItemDetails.Add(detail);
                    CurrentItemChanged?.Invoke(this, new ItemDetailViewModelEventArgs { Item = detail });
                }
            }
        }

        public void RemoveItemDetail(ItemDetailViewModel detail)
        {
            if (detail == null) throw new ArgumentNullException(nameof(detail));
            bool updateCurrentChanged = false;
            if (_currentItemDetails.IndexOf(detail) == _currentItemDetails.Count - 1)
            {
                updateCurrentChanged = true;
            }
            _currentItemDetails.Remove(detail);
            if (updateCurrentChanged)
            {
                ItemDetailViewModel lastItem = _currentItemDetails[_currentItemDetails.Count - 1];
                CurrentItemChanged?.Invoke(this, new ItemDetailViewModelEventArgs { Item = lastItem });
            }
        }
    }
}
