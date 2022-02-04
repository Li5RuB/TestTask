using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Models;

namespace TestTask.Repository.Repositories
{
    public interface ICountryRepository
    {
        public List<CountryItem> GetAllCountries();

        public Task<CountryItem> GetById(int id);

        public CountriesSearchResultModel GetCountriesToPage(string search, int skip, int take);
        
        public void Create(CountryItem user);

        public void Remove(CountryItem user);

        public void Update(CountryItem user);

        public Task Save();
    }
}
