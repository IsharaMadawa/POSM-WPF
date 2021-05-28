using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSM.wpf.State.Dialogs
{
	public interface IDialogRequestClose
	{
		event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
	}
}
