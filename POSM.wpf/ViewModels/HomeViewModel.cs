using POSM.wpf.Commands;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ViewBillingCommand { get; }
        public ICommand ViewSettingsCommand { get; }
        public ICommand avtivateNavigationCommand { get; set; }

        public HomeViewModel(IRenavigator billingRenavigator, IRenavigator settingsRenavigator, INavigationHandler navigationHandler)
		{
            ViewBillingCommand = new RenavigateCommand(billingRenavigator);
            ViewSettingsCommand = new RenavigateCommand(settingsRenavigator);

            avtivateNavigationCommand = new NavigationBarCommand(true, navigationHandler);
            avtivateNavigationCommand.Execute(null);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
