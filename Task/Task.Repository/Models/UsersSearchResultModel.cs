using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Models
{
    public class UsersSearchResultModel
    {
        public UsersSearchResultModel(List<UserItem> userItems, int totalUsers)
        {
            this.UserItems = userItems;
            this.TotalUsers = totalUsers;
        }

        public List<UserItem> UserItems { get; set; }

        public int TotalUsers { get; set; }
    }
}
