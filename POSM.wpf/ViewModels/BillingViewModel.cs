using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
	public class BillingViewModel : ViewModelBase
	{
        public BillingViewModel()
		{
            ErrorMessageViewModel = new MessageViewModel();
		}

        public ICommand ViewHomeCommand { get; }

        public MessageViewModel ErrorMessageViewModel { get; }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
