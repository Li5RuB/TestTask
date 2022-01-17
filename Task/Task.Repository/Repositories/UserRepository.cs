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

        public void CreateUser(UserItem user)
        {
            this.context.Users.Add(user);
        }

        public void RemoveUser(UserItem user)
        {
            this.context.Users.Remove(user);
        }

        public void UpdateUser(UserItem user)
        {
            this.context.Update(user);
        }

        public override async Task<UserItem> GetById(int id)
        {
            return await context.Users.FindAsync(id);
        }

        public async System.Threading.Tasks.Task Save()
        {
            await context.SaveChangesAsync();
        }
    }
}
