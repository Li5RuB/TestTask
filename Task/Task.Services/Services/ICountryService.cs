using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;

namespace Task.Services.Services
{
    public interface ICountryService
    {
        public Task<IEnumerable<CountryItem>> GetAll();

        public Task<CountryItem> GetById(int id);

        public Task<IEnumerable<CityItem>> GetCities();
    }
}
