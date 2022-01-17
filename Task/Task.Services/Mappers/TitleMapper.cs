using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
{
    public static class TitleMapper
    {
        public static TitleModel MapItemToModel(TitleItem item)
        {
            return new TitleModel()
            {
                TitleId = item.TitleId,
                Name = item.Name,
            };
        }

        public static IEnumerable<TitleModel> MapItemToModelRange(IEnumerable<TitleItem> items)
        {
            var result = new List<TitleModel>();
            foreach (var item in items)
            {
                result.Add(MapItemToModel(item));
            }
            return result;
        }

        public static TitleItem MapModelToItem(TitleModel model)
        {
            return new TitleItem()
            {
                TitleId = model.TitleId,
                Name = model.Name,
            };
        }
    }
}
