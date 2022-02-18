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
    public class RoleRepository : IRoleRepository
    {
        private readonly string _connectionString;
        public RoleRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetRoleByUserId(int userId)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<RoleItem>("SELECT Roles.Name FROM Roles " +
                    "inner join Users on Users.RoleId = Roles.RoleId " +
                    "WHERE UserId = @userId;", new { userId}).FirstOrDefault().Name;
            }
        }
    }
}
