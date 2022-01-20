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

        public UsersSearchResultModel GetUsersToPage(int skip, int take)
        {
            var allUsers = GetAll();
            var totalUsers = allUsers.Count();
            var userItems = allUsers.Skip(skip).Take(take).ToList();
            return new UsersSearchResultModel(userItems, totalUsers); ;
        }

        public UsersSearchResultModel Search(string search, int skip, int take)
        {
            var searchResult = GetAll().Where(i => i.Firstname.ToUpper().Contains(search.ToUpper()) || i.Lastname.ToUpper().Contains(search.ToUpper())
            || i.Email.ToUpper().Contains(search.ToUpper()) || i.Phone.ToUpper().Contains(search.ToUpper()));
            var totalUsers = searchResult.Count();
            var userItems = searchResult.Skip(skip).Take(take).ToList();
            return new UsersSearchResultModel(userItems, totalUsers);
        }
    }
}
