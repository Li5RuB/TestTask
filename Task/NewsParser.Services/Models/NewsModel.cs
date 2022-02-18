using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Models
{
    public class NewsModel
    {
        public NewsModel(string title, string briefContext, string url, DateTime date, string type)
        {
            Title = title;
            BriefContext = briefContext;
            Url = url;
            Date = date;
            Type = type;
        }

        public int NewsId { get; set; }

        public string Title { get; set; }

        public string BriefContext { get; set; }

        public string Url { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }
    }
}
