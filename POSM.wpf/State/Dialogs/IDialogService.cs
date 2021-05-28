namespace POSM.wpf.State.Dialogs
{
	public interface IDialogService
	{
		void Register<TViewModel, TView>() where TViewModel : IDialogRequestClose
										   where TView : IDialog;
		bool? ShowDialog<TViewModel>(TViewModel viewmodel) where TViewModel : IDialogRequestClose;
	}

}
