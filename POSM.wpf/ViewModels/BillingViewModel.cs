using POSM.wpf.Commands;
using POSM.wpf.State.Navigators;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
	public class BillingViewModel : ViewModelBase
	{

        public ICommand ViewHomeCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public BillingViewModel(IRenavigator HomeRenavigator)
		{
            ErrorMessageViewModel = new MessageViewModel();
            ViewHomeCommand = new RenavigateCommand(HomeRenavigator);
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
