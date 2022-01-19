using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Mappers
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
