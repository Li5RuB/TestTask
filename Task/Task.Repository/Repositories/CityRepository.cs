using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Data;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public class CityRepository : Repository<CityItem>, ICityRepository
    {
        public CityRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<CityItem> GetCitiesByCountryId(int id)
        {
            return this.context.Cities.Where(i => i.CountryId == id);
        }
    }
}
