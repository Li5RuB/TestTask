using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public interface IUserRepository
    {
        public Task<UserItem> GetById(int id);

        public IEnumerable<UserItem> GetAll();

        public void CreateUser(UserItem user);

        public void RemoveUser(UserItem user);

        public void UpdateUser(UserItem user);

        public System.Threading.Tasks.Task Save();
    }
}
