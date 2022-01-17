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
            services.AddDbContext<ApplicationDbContext>(options =>
   options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TestTask;User Id=koshin;password=Qwe123!@#;MultipleActiveResultSets=true"));

            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ITitleRepository, TitleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ITitleService, TitleService>();
            services.AddTransient<ICityService, CityService>();
        }
    }
}
