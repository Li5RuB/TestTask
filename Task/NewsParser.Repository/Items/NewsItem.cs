using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Repositories.Items
{
    public class NewsItem
    {
        public int NewsId { get; set; }

        public string Title { get; set; }

        public string BriefContext { get; set; }

        public string Url { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }
    }
}
