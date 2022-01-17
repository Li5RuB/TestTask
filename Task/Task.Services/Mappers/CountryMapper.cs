using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
{
    public static class CountryMapper
    {
        public static CountryModel MapItemToModel(CountryItem item)
        {
            return new CountryModel()
            {
                CountryId = item.CountryId,
                Name = item.Name,
            };
        }

        public static IEnumerable<CountryModel> MapItemToModelRange(IEnumerable<CountryItem> items)
        {
            var result = new List<CountryModel>();
            foreach (var item in items)
            {
                result.Add(MapItemToModel(item));
            }
            return result;
        }

        public static CountryItem MapModelToItem(CountryModel model)
        {
            return new CountryItem()
            {
                CountryId = model.CountryId,
                Name = model.Name,
            };
        }
    }
}
