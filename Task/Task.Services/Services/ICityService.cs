using System.Collections.Generic;
using System.Threading.Tasks;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface ICityService
    {
        public Task<CityModel> GetById(int id);

        public List<CityModel> GetCitiesByCountryId(int countryId);

        public Task CreateCity(CityModel user);

        public Task RemoveCity(int id);

        public Task UpdateCity(CityModel user);

        public CityPageModel GetCityPageModel(int page, string search);

        public Task<List<CityModel>> GetCountryForCities(List<CityModel> cityModels);
    }
}
