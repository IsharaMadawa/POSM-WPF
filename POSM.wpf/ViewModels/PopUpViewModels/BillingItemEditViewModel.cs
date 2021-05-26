using POSM.wpf.State.Navigators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSM.wpf.ViewModels.PopUpViewModels
{
	public class BillingItemEditViewModel : ViewModelBase
	{
		public MessageViewModel ErrorMessageViewModel { get; }

		public BillingItemEditViewModel()
		{
			ErrorMessageViewModel = new MessageViewModel();
		}

		public override void Dispose()
		{
			ErrorMessageViewModel.Dispose();

			base.Dispose();
		}
	}
}
