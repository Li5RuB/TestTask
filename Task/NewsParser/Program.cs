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
            #if DEBUG
                args = new[] { "send" };
            #endif
            var settings = new AppSettings();
            configuration.Bind("AppSettings", settings);
            var services = ConfigureServices(configuration.GetConnectionString("DefaultConnection"));
            var serviceProvider = services
                .AddSingleton<IAppSettings,AppSettings>(x=>settings)
                .BuildServiceProvider();
            serviceProvider.GetService<ProgramProcess>().Run(args[0]);
        }

        private static IServiceCollection ConfigureServices(string connection)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IUserRepository, UserRepository>(x=>new UserRepository(connection));
            services.AddTransient<INewsRepository, NewsRepository>(x=>new NewsRepository(connection));
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
