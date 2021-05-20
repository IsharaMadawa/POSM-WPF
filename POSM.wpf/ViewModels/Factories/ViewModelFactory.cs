using POSM.wpf.State.Navigators;
using System;

namespace POSM.wpf.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;
        private readonly CreateViewModel<BillingViewModel> _createBillingViewModel;

        public ViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<SettingsViewModel> createsettingsViewModel,
            CreateViewModel<BillingViewModel> createBillingViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createHomeViewModel = createHomeViewModel;
            _createSettingsViewModel = createsettingsViewModel;
            _createBillingViewModel = createBillingViewModel;
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
                case ViewType.Billing:
                    return _createBillingViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
