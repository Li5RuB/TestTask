using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Entities;

namespace Task.Repository.Repositories
{
    public interface ICountryRepository
    {
        public Task<IEnumerable<Country>> GetAll();

        public Task<Country> GetById(int id);

        public Task<IEnumerable<City>> GetCities();
    }
}
