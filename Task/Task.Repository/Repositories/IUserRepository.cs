using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Models;

namespace TestTask.Repository.Repositories
{
    public interface IUserRepository
    {
        public Task<UserItem> GetById(int id);

        public UsersSearchResultModel GetUsersToPage(ModelForSearch modelForSearch);

        public void Create(UserItem user);

        public void Remove(UserItem user);

        public void Update(UserItem user);

        public Task<UserItem> GetUserByEmail(string email);
        
        public Task Save();
    }
}
