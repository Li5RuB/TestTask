using Dapper;
using NewsParser.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Repositories.Repositories
{
    public class UserRepository : BaseRepository<UserItem>, IUserRepository
    {
        public UserRepository(string connectionString) : base(connectionString)
        {
        }

        public List<UserItem> GetUsers()
        {
            var sqlQuery = "select UserId, Firstname+' '+Lastname as Name" +
                ",Email, Roles.Name as RoleName from Users inner join Roles " +
                "on Users.RoleId = Roles.RoleId;";
            return ExecuteGetProcedure(sqlQuery).ToList();
        }
    }
}
