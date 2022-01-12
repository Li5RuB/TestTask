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
        private readonly ApplicationDbContext context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public void CreateUser(UserItem user)
        {
            this.context.Users.Add(user);
        }

        public IEnumerable<UserItem> GetUsers(Expression<Func<UserItem, bool>> expression)
        {
            return this.context.Users.Include(i=>i.City).ThenInclude(i=>i.Country).Include(i=>i.Title).Where(expression);
        }

        public void RemoveUser(UserItem user)
        {
            this.context.Users.Remove(user);
        }

        public void UpdateUser(UserItem user)
        {
            this.context.Update(user);
        }

    }
}
