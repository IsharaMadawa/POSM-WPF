using POSM.Domain.Exceptions;
using POSM.Domain.Services.ItemServices;
using POSM.EntityFramework.Models;
using POSM.wpf.ViewModels;
using System;
using System.Threading.Tasks;

namespace POSM.wpf.Commands
{
	public class GetItemCommand : AsyncCommandBase
	{
        private readonly IItemService _itemService;
        private readonly ItemViewModel _itemViewModel;
        private readonly BillingViewModel _billingViewModel;

        public MessageViewModel ErrorMessageViewModel { get; }

        public GetItemCommand(BillingViewModel billingViewModel, ItemViewModel itemViewModel, IItemService itemService)
		{
			_itemService = itemService;
            _itemViewModel = itemViewModel;
            _billingViewModel = billingViewModel;
        }

		public override async Task ExecuteAsync(object parameter)
		{
            _billingViewModel.ErrorMessage = string.Empty;

            try
            {
                Item stockPrice = await _itemService.GetItemById(_itemViewModel.Id);
            }
            catch (ItemNotFoundException)
            {
                _billingViewModel.ErrorMessage = "Item does not exist. Item Code : " + _itemViewModel.ItemCode;
            }
            catch (Exception)
            {
                _billingViewModel.ErrorMessage = "Failed to get item information. Item Code : " + _itemViewModel.ItemCode;
            }
        }
	}
}
