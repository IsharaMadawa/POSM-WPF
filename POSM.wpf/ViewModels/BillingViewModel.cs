using POSM.wpf.Commands;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
	public class BillingViewModel : ViewModelBase
	{
		public MessageViewModel ErrorMessageViewModel { get; }
		//public BindableCollection 

		public ICommand ViewHomeCommand { get; }
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
					   CheckItemUnit();
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

		public BillingViewModel(IRenavigator HomeRenavigator, INavigationHandler navigationHandler)
		{
			ErrorMessageViewModel = new MessageViewModel();

			ViewHomeCommand = new RenavigateCommand(HomeRenavigator);
			avtivateNavigationCommand = new NavigationBarCommand(false, navigationHandler);
			avtivateNavigationCommand.Execute(null);

			DisplayControl = false;
		}

		private void CheckItemUnit()
		{
			DisplayControl = !DisplayControl;
		}

		public override void Dispose()
		{
			base.Dispose();
		}
	}
}
