using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public interface ICityRepository
    {
        public List<CityItem> GetAllCities();

        public Task<CityItem> GetById(int id);

        public List<CityItem> GetCitiesByCountryId(int id);
    }
}
