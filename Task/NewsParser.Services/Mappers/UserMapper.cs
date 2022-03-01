using NewsParser.Repositories.Items;
using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Mappers
{
    public static class UserMapper
    {
        public static UserModel Map(UserItem item)
        {
            return new UserModel()
            {
                Name = item.Name,
                Email = item.Email,
                RoleName = item.RoleName,
            };
        }
    }
}
