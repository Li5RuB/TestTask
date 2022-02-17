using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System;
using NewsParser.Services;
using NewsParser.Settings;

namespace NewsParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"appsettings.json", optional: false)
                .Build();
            #if DEBUG
                args = new[] { "parse" };
#endif
            var settings = new AppSettings();
            configuration.Bind("AppSettings", settings);
            var services = ConfigureServices();
            var serviceProvider = services
                .AddSingleton<IAppSettings,AppSettings>(x=>settings)
                .BuildServiceProvider();
            serviceProvider.GetService<ProgramProcess>().Run(args[0]);
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IParser, OnlinerParser>();
            services.AddTransient<IParser, LentaParser>();
            services.AddTransient<IParser, YandexParser>();
            services.AddTransient<ProgramProcess>();
            return services;
        }
    }
}
