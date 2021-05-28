using System;
using System.Windows;

namespace POSM.wpf.State.Dialogs
{
	public interface IDialog
	{
		object DataContext { get; set; }
		bool? DialogResult { get; set; }
		Window Owner { get; set; }

		bool? ShowDialog();
		void Close();
	}
}
