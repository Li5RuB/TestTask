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
        public IEnumerable<UserModel> GetUsers(Expression<Func<UserItem, bool>> expression);

        public Task<UserModel> GetById(int id);

        public IEnumerable<UserModel> GetAll();

        public void CreateUser(UserModel user);

        public System.Threading.Tasks.Task RemoveUser(int id);

        public void UpdateUser(UserModel user);

        public IEnumerable<UserModel> GetByPage(int page);

        public IEnumerable<UserModel> Search(string search);

        public int GetPageCount();

        public System.Threading.Tasks.Task SaveChanges();
    }
}
