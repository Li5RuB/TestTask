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
    public class NewsRepository : BaseRepository<NewsItem>, INewsRepository
    {
        public NewsRepository(string connectionString) : base(connectionString)
        {
        }

        public void Create(NewsItem news)
        {
            var sqlQuery = "INSERT INTO News (Title, BriefContext, Url, Date, Type) VALUES(@Title, @BriefContext, @Url, @Date, @Type)";
            ExecuteSetProcedure(sqlQuery, news);
        }

        public NewsItem GetLastNews()
        {
            var sqlQuery = "SELECT TOP(1) * FROM News WHERE (SELECT MAX(Date) from News) = Date;";
            return ExecuteGetProcedure(sqlQuery).FirstOrDefault();
        }

        public NewsItem GetLastNewsByType(string type)
        {
            var sqlQuery = $"SELECT TOP(1) * FROM News WHERE (SELECT MAX(Date) from News where Type = {type}) = Date;";
            return ExecuteGetProcedure(sqlQuery).FirstOrDefault();
        }
    }
}
