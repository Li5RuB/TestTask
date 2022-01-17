using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;

namespace Task.Repository.Repositories
{
    public interface ICountryRepository
    {
        public IEnumerable<CountryItem> GetAll();

        public Task<CountryItem> GetById(int id);
    }
}
