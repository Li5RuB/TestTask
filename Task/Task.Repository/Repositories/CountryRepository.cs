using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Data;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public class CountryRepository : Repository<CountryItem>, ICountryRepository
    {
        private readonly ApplicationDbContext context;
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
            this.context = context;
        }

        public IEnumerable<CityItem> GetCities(int id)
        {
            return this.context.Cities.Include(i=>i.Country).Where(i=>i.CountryId == id);
        }
    }
}
