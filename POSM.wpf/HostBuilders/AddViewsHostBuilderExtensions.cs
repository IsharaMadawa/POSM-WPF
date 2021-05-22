using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POSM.wpf.ViewModels;
using POSM.wpf.Views.Settings;

namespace POSM.wpf.HostBuilders
{
    public static class AddViewsHostBuilderExtensions
    {
        public static IHostBuilder AddViews(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s => new MainWindow(s.GetRequiredService<MainViewModel>()));
            });

            return host;
        }
    }
}
