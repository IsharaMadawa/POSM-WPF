using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POSM.wpf.State.Accounts;
using POSM.wpf.State.Authenticators;
using POSM.wpf.State.Navigators;
using POSM.wpf.Stores;

namespace POSM.wpf.HostBuilders
{
    public static class AddStoresHostBuilderExtensions
    {
        public static IHostBuilder AddStores(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<INavigator, Navigator>();
                services.AddSingleton<INavigationHandler, NavigationHandler>();
                services.AddSingleton<IAuthenticator, Authenticator>();
                services.AddSingleton<IAccountStore, AccountStore>();
            });

            return host;
        }
    }
}
