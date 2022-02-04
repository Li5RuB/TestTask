using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class CountryRepository : BaseRepository<CountryItem>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context) { }

        public List<CountryItem> GetAllCountries()
        {
            return GetAll().ToList();
        }
    }
}
