using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using NewsParser.Services.Services;
using NewsParser.Repositories.Repositories;
using NewsParser.Common.Settings;

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
            var settings = new AppSettings();
            settings.Initialize(configuration);
            var services = ConfigureServices();
            var serviceProvider = services
                .AddSingleton<IAppSettings,AppSettings>(x=>settings)
                .AddSingleton<IRepositorySettings, RepositorySettings>(x=> (RepositorySettings)settings.RepositorySettings)
                .BuildServiceProvider();
            serviceProvider.GetService<ProgramProcess>().Run(args[0]);
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<INewsRepository, NewsRepository>();
            services.AddTransient<IGenerator, AdminMessageGenerator>();
            services.AddTransient<IGenerator, UserMessageGenerator>();
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ISendService, SendService>();
            services.AddTransient<IGeneratorService, GeneratorService>();
            services.AddScoped<IGeneratorFactory, GeneratorFactory>();
            services.AddTransient<IParser, OnlinerParser>();
            services.AddTransient<IParser, LentaParser>();
            services.AddTransient<IParser, BobrParser>();
            services.AddTransient<ProgramProcess>();
            return services;
        }
    }
}
