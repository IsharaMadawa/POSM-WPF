using POSM.wpf.State.Navigators;
using System;

namespace POSM.wpf.ViewModels.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly CreateViewModel<LoginViewModel> _createLoginViewModel;
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<BillingViewModel> _createBillingViewModel;
        private readonly CreateViewModel<SettingsViewModel> _createSettingsViewModel;

        public ViewModelFactory(CreateViewModel<LoginViewModel> createLoginViewModel, 
            CreateViewModel<HomeViewModel> createHomeViewModel,
            CreateViewModel<BillingViewModel> createBillingViewModel,
            CreateViewModel<SettingsViewModel> createSettingsViewModel)
        {
            _createLoginViewModel = createLoginViewModel;
            _createHomeViewModel = createHomeViewModel;
            _createBillingViewModel = createBillingViewModel;
            _createSettingsViewModel = createSettingsViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Login:
                    return _createLoginViewModel();
                case ViewType.Home:
                    return _createHomeViewModel();
                case ViewType.Billing:
                    return _createBillingViewModel();
                case ViewType.Settings:
                    return _createSettingsViewModel();
                default:
                    throw new ArgumentException("The ViewType does not have a ViewModel.", "viewType");
            }
        }
    }
}
