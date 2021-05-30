using Microsoft.AspNet.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POSM.Domain.Services;
using POSM.Domain.Services.AuthenticationServices;
using POSM.EntityFramework.Models;
using POSM.EntityFramework.Services.Common;

namespace POSM.wpf.HostBuilders
{
    public static class AddServicesHostBuilderExtensions
    {
        public static IHostBuilder AddServices(this IHostBuilder host)
        {
            host.ConfigureServices(services =>
            {
                services.AddSingleton<IPasswordHasher, PasswordHasher>();
                services.AddSingleton<IAuthenticationService, AuthenticationService>();
                services.AddSingleton<IDataService<User>, UserDataService>();
                services.AddSingleton<IUserService, UserDataService>();
            });

            return host;
        }
    }
}
