using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface IUserService
    {
        public Task<UserModel> GetById(int id);

        public void CreateUser(UserModel user);

        public Task RemoveUser(int id);

        public void UpdateUser(UserModel user);

        public List<UserModel> GetByPage(int page);

        public List<UserModel> Search(string search, int page);

        public int GetPageCount(string search = null);

        public Task<List<UserModel>> GetAllUserFields(List<UserModel> userModels);

        public UserPageModel GetUserPageModel(int page, string search);
    }
}
