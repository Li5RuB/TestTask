using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TestTask.Repository.Data;
using TestTask.Repository.Repositories;
using TestTask.Services.Hasher;
using TestTask.Services.Mappers;
using TestTask.Services.Services;

namespace TestTask.Web
{
    public static class DependencyInjection
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ITitleRepository, TitleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICountryService, CountryService>();
            services.AddTransient<ITitleService, TitleService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IAuthorizationService, AuthorizationService>();
        }

        public static void AddDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
        }
    }
}
