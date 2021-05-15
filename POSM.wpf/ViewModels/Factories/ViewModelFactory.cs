using POSM.wpf.State.Navigators;
using System;

namespace POSM.wpf.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;

        public ViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<SettingsViewModel> createsettingsViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createHomeViewModel = createHomeViewModel;
            _createSettingsViewModel = createsettingsViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
				case ViewType.Settings:
					return _createSettingsViewModel();
				default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
