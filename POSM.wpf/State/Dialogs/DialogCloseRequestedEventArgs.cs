using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POSM.wpf.State.Dialogs
{
	public class DialogCloseRequestedEventArgs : EventArgs
	{
		public bool? DialogResult { get; }

		public DialogCloseRequestedEventArgs(bool? dialogResult)
		{
			DialogResult = dialogResult;
		}
	}
}
