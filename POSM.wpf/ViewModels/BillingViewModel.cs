using POSM.wpf.Commands;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
	public class BillingViewModel : ViewModelBase
	{
		public MessageViewModel ErrorMessageViewModel { get; }

		public ICommand ViewHomeCommand { get; }
		public ICommand avtivateNavigationCommand { get; set; }
		public ICommand ViewItemEditCommand { get; set; }

		public ICommand clickk { get; set; }

		public bool IsLogIn = false;

		public bool _displayControl { get; set; }
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

			ViewItemEditCommand = new RelayCommand(butclick);
			ViewHomeCommand = new RenavigateCommand(HomeRenavigator);
			avtivateNavigationCommand = new NavigationBarCommand(false, navigationHandler);
			avtivateNavigationCommand.Execute(null);

			DisplayControl = false;
		}

		public void butclick(object e)
		{
			IsLogIn = !IsLogIn;
		}

		public override void Dispose()
		{
			base.Dispose();
		}




		//private ICommand _leftButtonDownCommand;

		//public ICommand LeftMouseButtonDown
		//{
		//	get
		//	{
		//		return _leftButtonDownCommand ?? (_leftButtonDownCommand = new RelayCommand(
		//		   x =>
		//		   {
		//			   DoStuff();
		//		   }));
		//	}
		//}


		private ICommand _closeEditCommad;

		public ICommand CloseEditCommad
		{
			get
			{
				return _closeEditCommad ?? (_closeEditCommad = new RelayCommand(
				   x =>
				   {
					   DoStuff();
				   }));
			}
		}

		private string _viewEventTrigger = "";
		public string ViewEventTrigger
		{
			get => _viewEventTrigger ?? (_viewEventTrigger = "");
			private set
			{
				if (_viewEventTrigger == value)
					return;

				_viewEventTrigger = value;
				//OnPropertyChanged();
			}
		}

		private bool _isGridVisible = false;
		public bool GridVisibility
		{
			get { return _isGridVisible; }
			set
			{
				_isGridVisible = value;
				//RaisePropertyChanged();
			}
		}

		private void ShowInfocenterIfAnyItinirary(object sender, ElapsedEventArgs e)
		{
			ViewEventTrigger = "true";
		}

		private void DoStuff()
		{
			//MessageBox.Show("Responding to left mouse button click event...");
			DisplayControl = !DisplayControl;
		}
	}
}
