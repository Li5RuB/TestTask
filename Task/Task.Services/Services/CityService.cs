using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Repository.Repositories;
using Task.Services.Mappers;
using Task.Services.Models;

namespace Task.Services.Services
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
            return CityMapper.MapItemToModelRange(this.cityRepository.GetAll());
        }

        public async Task<CityModel> GetById(int id)
        {
            return CityMapper.MapItemToModel(await cityRepository.GetById(id));
        }

        public IEnumerable<CityModel> GetCitiesByCountryId(int CountryId)
        {
            return CityMapper.MapItemToModelRange(cityRepository.GetCitiesByCountryId(CountryId));
        }
    }
}
