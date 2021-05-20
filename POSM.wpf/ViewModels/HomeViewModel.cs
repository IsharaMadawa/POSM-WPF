using POSM.wpf.Commands;
using POSM.wpf.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public ICommand ViewBillingCommand { get; }

        public HomeViewModel(IRenavigator homeRenavigator)
		{
            ViewBillingCommand = new RenavigateCommand(homeRenavigator);
		}

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
