using POSM.wpf.Commands;
using POSM.wpf.State.Navigators;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ViewBillingCommand { get; }
        public ICommand ViewSettingsCommand { get; }

        public HomeViewModel(IRenavigator billingRenavigator, IRenavigator settingsRenavigator)
		{
            ViewBillingCommand = new RenavigateCommand(billingRenavigator);
            ViewSettingsCommand = new RenavigateCommand(settingsRenavigator);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
