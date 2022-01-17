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
        public CountryRepository(ApplicationDbContext context) : base(context) { }

    }
}
