using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using POSM.wpf.Stores;
using POSM.wpf.ViewModels;
using POSM.wpf.ViewModels.Factories;
using POSM.wpf.ViewModels.PopUpViewModels;
using System;

namespace POSM.wpf.HostBuilders
{
    public static class AddViewModelsHostBuilderExtensions
    {
        public static IHostBuilder AddViewModels(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddTransient(CreateHomeViewModel);
                services.AddTransient<MainViewModel>();

                services.AddSingleton<CreateViewModel<HomeViewModel>>(services => () => services.GetRequiredService<HomeViewModel>());
                services.AddSingleton<CreateViewModel<LoginViewModel>>(services => () => CreateLoginViewModel(services));
                services.AddSingleton<CreateViewModel<BillingViewModel>>(services => () => CreateBillingViewModel(services));
                services.AddSingleton<CreateViewModel<SettingsViewModel>>(services => () => CreateSettingsViewModel(services));

				#region Pop-ups
				services.AddSingleton<CreateViewModel<BillingItemEditViewModel>>(services => () => CreateBillingItemEdiViewModel(services)); 
				#endregion

				services.AddSingleton<IViewModelFactory, ViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<BillingViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<SettingsViewModel>>();
            });

            return host;
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(
                 services.GetRequiredService<ViewModelDelegateRenavigator<BillingViewModel>>(),
                 services.GetRequiredService<ViewModelDelegateRenavigator<SettingsViewModel>>(),
                 services.GetRequiredService<INavigationHandler>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
        }

        private static SettingsViewModel CreateSettingsViewModel(IServiceProvider services)
        {
            return new SettingsViewModel(services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
        }

        private static BillingViewModel CreateBillingViewModel(IServiceProvider services)
        {
            return new BillingViewModel(services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>(),
                services.GetRequiredService<INavigationHandler>());
        }

		#region Pop-ups
		private static BillingItemEditViewModel CreateBillingItemEdiViewModel(IServiceProvider services)
		{
			return new BillingItemEditViewModel();
		} 
		#endregion
	}
}
