using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
{
    public static class CityMapper
    {
        public static CityModel MapItemToModel(CityItem item)
        {
            return new CityModel()
            {
                CityId = item.CityId,
                Name = item.Name,
                CountryId = item.CountryId,
            };
        }

        public static IEnumerable<CityModel> MapItemToModelRange(IEnumerable<CityItem> items)
        {
            var result = new List<CityModel>();
            foreach(var item in items)
            {
                result.Add(MapItemToModel(item));
            }
            return result;
        }
        public static CityItem MapModelToItem(CityModel model)
        {
            return new CityItem()
            {
                CityId = model.CityId,
                Name = model.Name,
                CountryId = model.CountryId,
            };
        }
    }
}
