using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;
using TestTask.Repository.Models;

namespace TestTask.Repository.Repositories
{
    public class CountryRepository : BaseRepository<CountryItem>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context) { }

        public List<CountryItem> GetAllCountries()
        {
            return GetAll().ToList();
        }

        public CountriesSearchResultModel GetCountriesToPage(int skip, int take)
        {
            var countries = GetAll();
            var totalCountries = countries.Count();
            var countriesPerPage = countries.Skip(skip).Take(take).ToList();
            return new CountriesSearchResultModel(countriesPerPage, totalCountries);
        }

        public CountriesSearchResultModel Search(string search, int skip, int take)
        {
            var countries = GetAll().Where(i => i.Description.ToUpper().Contains(search.ToUpper()) || i.Name.ToUpper().Contains(search.ToUpper()));
            var totalCountries = countries.Count();
            var countriesPerPage = countries.Skip(skip).Take(take).ToList();
            return new CountriesSearchResultModel(countriesPerPage, totalCountries);
        }
    }
}
