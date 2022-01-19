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

    }
}
