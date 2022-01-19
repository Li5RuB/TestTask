using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public interface ICountryRepository
    {
        public List<CountryItem> GetAllCountries();

        public Task<CountryItem> GetById(int id);
    }
}
