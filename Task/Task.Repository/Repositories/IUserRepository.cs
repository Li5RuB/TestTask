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

        public IEnumerable<UserItem> GetUsersToPage(int page);

        public int GetCount();

        public void Create(UserItem user);

        public void Remove(UserItem user);

        public void Update(UserItem user);

        public IEnumerable<UserItem> Search(Expression<Func<UserItem, bool>> expression, int page);

        public int GetSearchCount(Expression<Func<UserItem, bool>> expression);

        public System.Threading.Tasks.Task Save();
    }
}
