using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Models
{
    public class UsersAndTotalUsersModel
    {
        public UsersAndTotalUsersModel(List<UserItem> userItems, int totalUsers)
        {
            UserItems = userItems;
            TotalUsers = totalUsers;
        }

        public List<UserItem> UserItems { get; set; }

        public int TotalUsers { get; set; }
    }
}
