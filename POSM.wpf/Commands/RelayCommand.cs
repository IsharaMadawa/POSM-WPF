using POSM.wpf.State.Authenticators;
using POSM.wpf.ViewModels;
using System;
using System.Windows.Input;

namespace POSM.wpf.Commands
{
	public class RelayCommand : ICommand
    {
        private readonly INavigationHandler _navigationHandler;
        private readonly BillingViewModel _viewModel;
		public event EventHandler CanExecuteChanged;

		public RelayCommand(BillingViewModel viewModel, INavigationHandler navigationHandler)
        {
            _viewModel = viewModel;
            _navigationHandler = navigationHandler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _navigationHandler.UpdateNavBarStatus(_viewModel.isShowNav);
        }
	}
}