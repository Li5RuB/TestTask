using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Repository.Data;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Services;

namespace TestTask.Web
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
