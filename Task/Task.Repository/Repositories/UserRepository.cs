using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;
using TestTask.Repository.Models;

namespace TestTask.Repository.Repositories
{
    public class UserRepository : BaseRepository<UserItem>, IUserRepository
    {
        
        public UserRepository(ApplicationDbContext context) : base(context){ }

        public UsersAndTotalUsersModel GetUsersToPage(int page, int skip, int take)
        {
            var a = GetAll();
            var totalUsers = a.Count();
            var userItems = a.Skip(skip).Take(take).ToList();
            return new UsersAndTotalUsersModel(userItems, totalUsers); ;
        }

        public UsersAndTotalUsersModel Search(string search, int page, int skip, int take)
        {
            var a = GetAll().Where(i => i.Firstname.ToUpper().Contains(search.ToUpper()) || i.Lastname.ToUpper().Contains(search.ToUpper())
            || i.Email.ToUpper().Contains(search.ToUpper()) || i.Phone.ToUpper().Contains(search.ToUpper()));
            var totalUsers = a.Count();
            var userItems = a.Skip(skip).Take(take).ToList();
            return new UsersAndTotalUsersModel(userItems, totalUsers);
        }
    }
}
