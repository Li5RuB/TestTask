using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Entities;

namespace Task.Repository.Repositories
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers(Expression<Func<User, bool>> expression);

        public Task<User> GetById(int id);

        public Task<IEnumerable<User>> GetAll();

        public void CreateUser(User user);

        public void RemoveUser(User user);

        public void UpdateUser(User user);

        public void SaveChanges();
    }
}
