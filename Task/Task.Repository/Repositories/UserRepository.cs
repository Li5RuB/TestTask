using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Data;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public class UserRepository : Repository<UserItem>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context){ }

        public IEnumerable<UserItem> GetUsersToPage(int page)
        {
            const int numberOfUsersPerPage = 3;
            IQueryable<UserItem> users = context.Users;
            return users.Skip(page * numberOfUsersPerPage - numberOfUsersPerPage).Take(numberOfUsersPerPage);
        }

        public IEnumerable<UserItem> Search(Expression<Func<UserItem,bool>> expression, int page)
        {
            const int numberOfUsersPerPage = 3;
            IQueryable<UserItem> users = context.Users;
            return users.Where(expression).Skip(page * numberOfUsersPerPage - numberOfUsersPerPage).Take(numberOfUsersPerPage);

        }

        public int GetCount()
        {
            return context.Users.Count();
        }

        public int GetSearchCount(Expression<Func<UserItem, bool>> expression)
        {
            return context.Users.Count(expression);
        }
    }
}
