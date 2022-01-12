using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;

namespace Task.Services.Services
{
    public class CountryService : ICountryService
    {
        public Task<IEnumerable<CountryItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<CountryItem> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CityItem>> GetCities()
        {
            throw new NotImplementedException();
        }
    }
}
