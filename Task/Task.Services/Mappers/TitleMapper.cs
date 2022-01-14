using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
{
    public class TitleMapper : IMapper<TitleItem, TitleModel>
    {
        public TitleModel MapItemToModel(TitleItem item)
        {
            return new TitleModel()
            {
                Id = item.Id,
                Name = item.Name,
            };
        }

        public IEnumerable<TitleModel> MapItemToModelRange(IEnumerable<TitleItem> items)
        {
            var result = new List<TitleModel>();
            foreach (var item in items)
            {
                result.Add(MapItemToModel(item));
            }
            return result;
        }

        public TitleItem MapModelToItem(TitleModel model)
        {
            return new TitleItem()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
