using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository cityRepository;

        public CityService(ICityRepository cityRepository)
        {
            this.cityRepository = cityRepository;
        }

        public IEnumerable<CityModel> GetAll()
        {
            var cities = cityRepository.GetAllCities();
            var result = cities.Select(x => CityMapper.MapItemToModel(x)).ToList();
            return result;
        }

        public async Task<CityModel> GetById(int id)
        {
            return CityMapper.MapItemToModel(await cityRepository.GetById(id));
        }

        public IEnumerable<CityModel> GetCitiesByCountryId(int CountryId)
        {
            var cities = cityRepository.GetCitiesByCountryId(CountryId);
            var result = cities.Select(x=>CityMapper.MapItemToModel(x)).ToList(); 
            return result;
        }
    }
}
