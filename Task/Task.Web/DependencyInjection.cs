using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task.Repository.Data;
using Task.Repository.Repositories;
using Task.Services.Mappers;
using Task.Services.Services;

namespace Task.Web
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<UnitOfWork>();

            services.AddTransient<UserMapper>();
            services.AddTransient<CountryMapper>();
            services.AddTransient<CityMapper>();
            services.AddTransient<TitleMapper>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ITitleService, TitleService>();
            services.AddTransient<ICityService, CityService>();
        }
    }
}
