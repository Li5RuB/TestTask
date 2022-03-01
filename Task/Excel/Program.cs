using Excel.Services.Settings;
using Microsoft.Extensions.Configuration;
using System;
using Microsoft.Extensions.DependencyInjection;
using Excel.Services.Services;

namespace Excel

{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile($"appsettings.json", optional: false)
                .Build();
            var settings = new AppSettings();
            configuration.Bind("paths", settings);
            var services = ConfigureServices();
            var serviceProvider = services
                .AddSingleton<IAppSettings, AppSettings>(x => settings)
                .BuildServiceProvider();
            serviceProvider.GetService<ProgramProcess>().Run();
        }
        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IParseService, ParseService>();
            services.AddTransient<IGenerateService, GenerateService>();
            services.AddTransient<ProgramProcess>();
            return services;
        }
    }
}

