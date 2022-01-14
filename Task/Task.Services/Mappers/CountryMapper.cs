using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
{
    public class CountryMapper : IMapper<CountryItem, CountryModel>
    {
        public CountryModel MapItemToModel(CountryItem item)
        {
            return new CountryModel()
            {
                Id = item.Id,
                Name = item.Name,
            };
        }

        public IEnumerable<CountryModel> MapItemToModelRange(IEnumerable<CountryItem> items)
        {
            var result = new List<CountryModel>();
            foreach (var item in items)
            {
                result.Add(MapItemToModel(item));
            }
            return result;
        }

        public CountryItem MapModelToItem(CountryModel model)
        {
            return new CountryItem()
            {
                Id = model.Id,
                Name = model.Name,
            };
        }
    }
}
