using Dapper;
using NewsParser.Common.Settings;
using NewsParser.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Repositories.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(IRepositorySettings settings) : base(settings)
        {
        }

        public List<UserItem> GetUsers()
        {
            var sqlQuery = "select UserId, Firstname as Name" +
                ",Email, Roles.Name as RoleName from Users inner join Roles " +
                "on Users.RoleId = Roles.RoleId;";
            return ExecuteGetProcedure<UserItem>(sqlQuery).ToList();
        }
    }
}
