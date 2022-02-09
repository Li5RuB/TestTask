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

        public CountriesSearchResultModel GetCountriesToPage(string search, int skip, int take)
        {
            IQueryable<CountryItem> countries;
            countries = search != null ? GetAll().Where(i => 
                i.Description.ToUpper().Contains(search.ToUpper()) 
                || i.Name.ToUpper().Contains(search.ToUpper())) : GetAll();
            var totalCountries = countries.Count();
            var countriesPerPage = countries.Skip(skip).Take(take).ToList();
            return new CountriesSearchResultModel(countriesPerPage, totalCountries);
        }
    }
}
