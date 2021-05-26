using POSM.wpf.Commands;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
	public class BillingViewModel : ViewModelBase
	{
		public MessageViewModel ErrorMessageViewModel { get; }
		public ICommand ViewHomeCommand { get; }
		public ICommand avtivateNavigationCommand { get; set; }
		//private bool _isActivateNavigation = false;
		//public bool isActivateNavigation
		//{
		//	get { return _isActivateNavigation; }
		//	set
		//	{
		//		_isActivateNavigation = value;
		//		OnPropertyChanged("isActivateNavigation");
		//	}
		//}

		public BillingViewModel(IRenavigator HomeRenavigator, INavigationHandler navigationHandler)
		{
			ErrorMessageViewModel = new MessageViewModel();

			ViewHomeCommand = new RenavigateCommand(HomeRenavigator);
			avtivateNavigationCommand = new NavigationBarCommand(false, navigationHandler);
			avtivateNavigationCommand.Execute(null);
		}

		public override void Dispose()
		{
			base.Dispose();
		}

	}
}
