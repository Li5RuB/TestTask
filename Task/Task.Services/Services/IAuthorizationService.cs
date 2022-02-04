using System.Security.Claims;
using System.Threading.Tasks;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface IAuthorizationService
    {
        public Task<UserModel> LoginUser(LoginModel model);

        public Task RegisterUser(RegisterModel model);

        public Task<ClaimsIdentity> GetClaimsIdentity(UserModel user);
    }
}