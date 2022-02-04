using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface IUserService
    {
        public Task<UserModel> GetById(int id);

        public Task CreateUser(UserModel user);

        public Task RemoveUser(int id);

        public Task UpdateUser(UserModel user);

        public Task<List<UserModel>> GetAllUserFields(List<UserModel> userModels);

        public Task<UserPageModel> GetUserPageModel(UserPageModel model);

        public Task<UserModel> GetUserByEmail(string email);
    }
}
