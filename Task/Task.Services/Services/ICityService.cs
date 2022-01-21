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
        public List<CityModel> GetAll();

        public Task<CityModel> GetById(int id);

        public List<CityModel> GetCitiesByCountryId(int CountryId);

        public Task CreateCity(CityModel user);

        public Task RemoveCity(int id);

        public Task UpdateCity(CityModel user);

        public CityPageModel GetCityPageModel(int page, string search);
    }
}
