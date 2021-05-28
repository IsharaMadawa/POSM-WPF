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
        public ICommand AvtivateNavigationCommand { get; set; }
        

        public HomeViewModel(IRenavigator billingRenavigator, IRenavigator settingsRenavigator, INavigationHandler navigationHandler)
		{
            ViewBillingCommand = new RenavigateCommand(billingRenavigator);
            ViewSettingsCommand = new RenavigateCommand(settingsRenavigator);

            AvtivateNavigationCommand = new NavigationBarCommand(true, navigationHandler);
            AvtivateNavigationCommand.Execute(null);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
