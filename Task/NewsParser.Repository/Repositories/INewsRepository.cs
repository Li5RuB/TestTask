using NewsParser.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Repositories.Repositories
{
    public interface INewsRepository
    {
        public void Create(NewsItem news);

        public NewsItem GetLastNews();

        public NewsItem GetLastNewsByType(string type);
    }
}
