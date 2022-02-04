using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;
using TestTask.Repository.Models;
using System.Linq.Dynamic.Core;

namespace TestTask.Repository.Repositories
{
    public class UserRepository : BaseRepository<UserItem>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context){ }

        public UsersSearchResultModel GetUsersToPage(ModelForSearch modelForSearch)
        {
            var searchResult = GetSearchResult(modelForSearch);
            var totalUsers = searchResult.Count();
            searchResult = SortItems(modelForSearch.Sort, searchResult);
            var userItems = searchResult.Skip(modelForSearch.Skip).Take(modelForSearch.Take).ToList();
            return new UsersSearchResultModel(userItems, totalUsers);
        }

        private IQueryable<UserItem> GetSearchResult(ModelForSearch modelForSearch)
        {
            IQueryable<UserItem> searchResult;
            if (modelForSearch.Search == null)
                searchResult = GetAll();
            else
                searchResult = GetAll().Where(i => i.Firstname.ToUpper().Contains(modelForSearch.Search.ToUpper())
                                                   || i.Lastname.ToUpper().Contains(modelForSearch.Search.ToUpper())
                                                   || i.Email.ToUpper().Contains(modelForSearch.Search.ToUpper())
                                                   || i.Phone.ToUpper().Contains(modelForSearch.Search.ToUpper()));
            return searchResult;
        }

        public async Task<UserItem> GetUserByEmail(string email)
        {
            return await GetAll().FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());
        }
        
        private static IQueryable<UserItem> SortItems(Dictionary<string, string> sort, IQueryable<UserItem> allUsers)
        {
            if (sort?.Count > 0)
            {
                string s = "";
                for (var i = 0;i<sort.Count;i++)
                {
                    s += $"{sort.ElementAt(i).Key} {(sort.ElementAt(i).Value == "desc" ? "desc" : "")}";
                    if (i<sort.Count-1)
                    {
                        s += ',';
                    }
                }
                allUsers = allUsers.OrderBy(s);
            }
            return allUsers;
        }
    }
}
