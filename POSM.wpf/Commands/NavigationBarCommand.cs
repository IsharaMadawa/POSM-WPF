using POSM.wpf.State.Authenticators;
using POSM.wpf.ViewModels;
using System;
using System.Windows.Input;

namespace POSM.wpf.Commands
{
	public class NavigationBarCommand : ICommand
    {
        private readonly INavigationHandler _navigationHandler;
        private readonly bool _isActivate;
		public event EventHandler CanExecuteChanged;

		public NavigationBarCommand(bool isActivate, INavigationHandler navigationHandler)
        {
            _isActivate = isActivate;
            _navigationHandler = navigationHandler;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _navigationHandler.UpdateNavBarStatus(_isActivate);
        }
	}
}