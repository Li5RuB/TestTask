using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public interface ICityRepository
    {
        public IEnumerable<CityItem> GetAll();

        public Task<CityItem> GetById(int id);

        public IEnumerable<CityItem> GetCitiesByCountryId(int id);
    }
}
