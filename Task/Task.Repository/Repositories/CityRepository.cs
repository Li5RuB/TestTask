using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class CityRepository : BaseRepository<CityItem>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context) { }

        public List<CityItem> GetCitiesByCountryId(int id)
        {
            return GetAll().Where(i => i.CountryId == id).ToList();
        }

        public List<CityItem> GetAllCities()
        {
            return GetAll().ToList();
        }
    }
}
