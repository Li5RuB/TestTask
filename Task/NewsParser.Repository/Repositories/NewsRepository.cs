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
    public class NewsRepository : INewsRepository
    {
        private readonly string _connectionString;
        public NewsRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Create(NewsItem news)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                var sqlQuery = "INSERT INTO News (Title, BriefContext, Url, Date, Type) VALUES(@Title, @BriefContext, @Url, @Date, @Type)";
                db.Execute(sqlQuery, news);
            }
        }

        public NewsItem GetLastNews()
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<NewsItem>("SELECT TOP(1) * FROM News WHERE (SELECT MAX(Date) from News) = Date;").FirstOrDefault();
            }
        }

        public NewsItem GetLastNewsByType(string type)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return db.Query<NewsItem>("SELECT TOP(1) * FROM News WHERE (SELECT MAX(Date) from News where Type = @type) = Date;", new { type}).FirstOrDefault();
            }
        }
    }
}
