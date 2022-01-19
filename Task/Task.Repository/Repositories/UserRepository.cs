using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class UserRepository : BaseRepository<UserItem>, IUserRepository
    {
        private const int numberOfUsersPerPage = 3;
        public UserRepository(ApplicationDbContext context) : base(context){ }

        public List<UserItem> GetUsersToPage(int page)
        {
            return GetAll().Skip(page * numberOfUsersPerPage - numberOfUsersPerPage).Take(numberOfUsersPerPage).ToList();
        }

        public List<UserItem> Search(Expression<Func<UserItem,bool>> expression, int page)
        {
            return GetAll().Where(expression).Skip(page * numberOfUsersPerPage - numberOfUsersPerPage).Take(numberOfUsersPerPage).ToList();

        }

        public int GetCount()
        {
            return GetAll().Count();
        }

        public int GetSearchCount(Expression<Func<UserItem, bool>> expression)
        {
            return GetAll().Count(expression);
        }
    }
}
