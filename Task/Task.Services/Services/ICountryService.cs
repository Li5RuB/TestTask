using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Services
{
    public interface ICountryService
    {
        public IEnumerable<CountryModel> GetAll();

        public Task<CountryModel> GetById(int id);
    }
}
