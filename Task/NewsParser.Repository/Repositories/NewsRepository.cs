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
    public class NewsRepository : BaseRepository, INewsRepository
    {
        public NewsRepository(IRepositorySettings settings) : base(settings)
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
            return ExecuteGetProcedure<NewsItem>(sqlQuery).FirstOrDefault();
        }

        public NewsItem GetLastNewsByType(string type)
        {
            var sqlQuery = $"SELECT TOP(1) * FROM News WHERE (SELECT MAX(Date) from News where Type = '{type}') = Date;";
            return ExecuteGetProcedure<NewsItem>(sqlQuery).FirstOrDefault();
        }
    }
}
