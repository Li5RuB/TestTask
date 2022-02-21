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
    public class BaseRepository<T> where T : class 
    {
        private readonly string _connectionString;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected List<T> ExecuteGetProcedure(string sqlQuery)
        {
            return GetDbContext().Query<T>(sqlQuery).ToList();
        }

        protected void ExecuteSetProcedure(string sqlQuery, T news)
        {
            GetDbContext().Execute(sqlQuery, news);
        }

        private SqlConnection GetDbContext()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
