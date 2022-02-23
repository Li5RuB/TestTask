using NewsParser.Repositories.Items;
using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Mappers
{
    public static class NewsMapper
    {
        public static NewsModel MapItemToModel(NewsItem item)
        {
            return new NewsModel(item.Title, item.BriefContext, item.Url, item.Date, item.Type);
        }

        public static NewsItem MapModelToItem(NewsModel model)
        {
            return new NewsItem()
            {
                Title = model.Title,
                BriefContext = model.BriefContext,
                Url = model.Url,
                Date = model.Date,
                Type = model.Type
            };
        }
    }
}
