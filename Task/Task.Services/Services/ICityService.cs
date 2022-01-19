using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface ICityService
    {
        public IEnumerable<CityModel> GetAll();

        public Task<CityModel> GetById(int id);

        public IEnumerable<CityModel> GetCitiesByCountryId(int CountryId);
    }
}
