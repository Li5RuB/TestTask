using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Services
{
    public interface IUserService
    {
        public Task<UserModel> GetById(int id);

        public IEnumerable<UserModel> GetAll();

        public void CreateUser(UserModel user);

        public System.Threading.Tasks.Task RemoveUser(int id);

        public void UpdateUser(UserModel user);

        public Task<IEnumerable<UserModel>> GetByPage(int page);

        public IEnumerable<UserModel> Search(string search);

        public int GetPageCount(IEnumerable<UserModel> users);

        public Task<IEnumerable<UserModel>> GetAllUserFields(List<UserModel> userModels);

        public System.Threading.Tasks.Task SaveChanges();
    }
}
