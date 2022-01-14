using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
{
    public class CityMapper : IMapper<CityItem, CityModel>
    {
        private readonly CountryMapper countryMapper;

        public CityMapper(CountryMapper countryMapper)
        {
            this.countryMapper = countryMapper;
        }

        public CityModel MapItemToModel(CityItem item)
        {
            return new CityModel()
            {
                Id = item.Id,
                Name = item.Name,
                CountryId = item.CountryId,
                Country = countryMapper.MapItemToModel(item.Country)
            };
        }

        public IEnumerable<CityModel> MapItemToModelRange(IEnumerable<CityItem> items)
        {
            var result = new List<CityModel>();
            foreach(var item in items)
            {
                result.Add(MapItemToModel(item));
            }
            return result;
        }
        public CityItem MapModelToItem(CityModel model)
        {
            return new CityItem()
            {
                Id = model.Id,
                Name = model.Name,
                CountryId = model.CountryId,
            };
        }
    }
}
