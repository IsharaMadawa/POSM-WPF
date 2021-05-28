using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using POSM.EntityFramework;
using POSM.EntityFramework.Models;
using System;

namespace POSM.wpf.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sqlServer");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionString);

                services.AddDbContext<POSMContext>(configureDbContext);
                services.AddSingleton<POSMContextFactory>(new POSMContextFactory(configureDbContext));
            });
            return host;
        }
    }
}
