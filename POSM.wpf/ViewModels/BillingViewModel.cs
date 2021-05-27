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
