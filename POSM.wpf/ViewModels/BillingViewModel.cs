using POSM.Domain.Services.ItemServices;
using POSM.wpf.Commands;
using POSM.wpf.Helpers;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
	public class BillingViewModel : ViewModelBase
	{
		private DebounceDispatcher debounceTimer = new DebounceDispatcher();

		public ObservableCollection<ItemViewModel> _items = new ObservableCollection<ItemViewModel>();
		public ObservableCollection<ItemViewModel> Items
		{
			get { return this._items; }
		}

		public ICommand ViewHomeCommand { get; }
		//public ICommand GetItemCommand { get; }
		public ICommand avtivateNavigationCommand { get; set; }
		public ICommand ViewItemEditCommand { get; set; }
		private ICommand _showItemEdit;
		public ICommand ShowItemEdit
		{
			get
			{
				return _showItemEdit ?? (_showItemEdit = new RelayCommand(
				   x =>
				   {
					   debounceTimer.Debounce(500, (p) => { CheckItemUnit((string)x); });
				   }));
			}
		}

		private bool _displayControl { get; set; }
		public bool DisplayControl
		{
			get { return _displayControl; }
			set
			{
				_displayControl = value;
				OnPropertyChanged("DisplayControl");
			}
		}

		public MessageViewModel ErrorMessageViewModel { get; }
		public string ErrorMessage
		{
			set => ErrorMessageViewModel.Message = value;
		}
		private string _readingItemCode { get; set; }
		public string readingItemCode
		{
			get { return _readingItemCode; }
			set
			{
				_readingItemCode = value;
				OnPropertyChanged("readingItemCode");
			}
		}

		public BillingViewModel(IRenavigator HomeRenavigator, INavigationHandler navigationHandler)
		{
			ErrorMessageViewModel = new MessageViewModel();

			ViewHomeCommand = new RenavigateCommand(HomeRenavigator);
			//GetItemCommand = new GetItemCommand(this, _items, iitemService);
			avtivateNavigationCommand = new NavigationBarCommand(false, navigationHandler);
			avtivateNavigationCommand.Execute(null);

			DisplayControl = false;
		}

		private void CheckItemUnit(string parm)
		{
			if(parm == "Open" && _readingItemCode != string.Empty)
			{
				ItemViewModel _item = new ItemViewModel()
				{
					Id = 1,
					ItemName = "POLO",
					ItemCode = _readingItemCode
				};
				_items.Add(_item);
			}
			readingItemCode = string.Empty;
			//DisplayControl = !DisplayControl;
		}

		public override void Dispose()
		{
			base.Dispose();
		}
	}
}
