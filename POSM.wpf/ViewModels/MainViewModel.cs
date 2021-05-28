using POSM.wpf.Commands;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Dialogs;
using POSM.wpf.State.Navigators;
using POSM.wpf.Stores;
using POSM.wpf.ViewModels.Factories;
using System.Windows.Input;

namespace POSM.wpf.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;
        private readonly INavigationHandler _navigationHandler;

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;

        public ICommand UpdateCurrentViewModelCommand { get; }

        public bool _isShowNavigation = true;
        public bool isShowNavigation
		{
            get { return _isShowNavigation; }
            set
			{
				_isShowNavigation = value;
				OnPropertyChanged("isShowNavigation");
            }
        }

        public MainViewModel(INavigator navigator, IViewModelFactory viewModelFactory, IAuthenticator authenticator, INavigationHandler navigationHandler)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
            _authenticator = authenticator;
            _navigationHandler = navigationHandler;

            _navigator.StateChanged += Navigator_StateChanged;
            _authenticator.StateChanged += Authenticator_StateChanged;
            _navigationHandler.showNavigationBar += Navigation_StateChanged;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        private void Authenticator_StateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

		private void Navigator_StateChanged()
		{
			OnPropertyChanged(nameof(CurrentViewModel));
		}

        private void Navigation_StateChanged(bool isActivate)
        {
            isShowNavigation = isActivate;
        }

        public override void Dispose()
        {
            _navigator.StateChanged -= Navigator_StateChanged;
            _authenticator.StateChanged -= Authenticator_StateChanged;
            _navigationHandler.showNavigationBar -= Navigation_StateChanged;

            base.Dispose();
        }
    }
}
