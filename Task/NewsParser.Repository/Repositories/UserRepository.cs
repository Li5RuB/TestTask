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
    public class UserRepository : IUserRepository
    {
        private readonly string _connectionString;
        public UserRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<UserItem> GetUsers()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<UserItem>("SELECT * FROM Users").ToList();
            }
        }
    }
}
