using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;
using TestTask.Repository.Models;

namespace TestTask.Repository.Repositories
{
    public class CityRepository : BaseRepository<CityItem>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context) { }

        public List<CityItem> GetCitiesByCountryId(int id)
        {
            return GetAll().Where(i => i.CountryId == id).ToList();
        }

        public CitiesSearchResultModel GetCitiesToPage(string search, int skip, int take)
        {
            IQueryable<CityItem> cities;
            cities = search!=null ? GetAll().Where(i => i.Name.ToUpper().Contains(search.ToUpper())) : GetAll();
            var totalCities = cities.Count();
            var citiesPerPage = cities.Skip(skip).Take(take).ToList();
            return new CitiesSearchResultModel(citiesPerPage, totalCities);
        }
    }
}
