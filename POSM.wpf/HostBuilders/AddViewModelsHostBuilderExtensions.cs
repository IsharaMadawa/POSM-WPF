using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using POSM.wpf.ViewModels;
using POSM.wpf.ViewModels.Factories;
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
                services.AddSingleton<CreateViewModel<SettingsViewModel>>(services => () => CreateSettingsViewModel(services));
                services.AddSingleton<CreateViewModel<BillingViewModel>>(services => () => CreateBillingViewModel(services));

                services.AddSingleton<IViewModelFactory, ViewModelFactory>();

                services.AddSingleton<ViewModelDelegateRenavigator<HomeViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<LoginViewModel>>();
                services.AddSingleton<ViewModelDelegateRenavigator<BillingViewModel>>();
            });

            return host;
        }

        private static HomeViewModel CreateHomeViewModel(IServiceProvider services)
        {
            return new HomeViewModel(
                 services.GetRequiredService<ViewModelDelegateRenavigator<BillingViewModel>>());
        }

        private static LoginViewModel CreateLoginViewModel(IServiceProvider services)
        {
            return new LoginViewModel(
                services.GetRequiredService<IAuthenticator>(),
                services.GetRequiredService<ViewModelDelegateRenavigator<HomeViewModel>>());
        }

        private static SettingsViewModel CreateSettingsViewModel(IServiceProvider services)
        {
            return new SettingsViewModel();
        }

        private static BillingViewModel CreateBillingViewModel(IServiceProvider services)
        {
            return new BillingViewModel();
        }
    }
}
