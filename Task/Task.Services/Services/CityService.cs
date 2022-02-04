using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private const int DefaultCityPage = 1;
        private const int NumberOfCityPerPage = 8;

        public CityService(ICityRepository cityRepository, ICountryRepository countryRepository)
        {
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
        }

        public async Task CreateCity(CityModel user)
        {
            _cityRepository.Create(CityMapper.MapModelToItem(user));
            await _cityRepository.Save();
        }

        public async Task<CityModel> GetById(int id)
        {
            return CityMapper.MapItemToModel(await _cityRepository.GetById(id));
        }

        public List<CityModel> GetCitiesByCountryId(int countryId)
        {
            var cities = _cityRepository.GetCitiesByCountryId(countryId);
            var result = cities.Select(CityMapper.MapItemToModel).ToList(); 
            return result;
        }

        public CityPageModel GetCityPageModel(int page, string search)
        {
            if (!(page > DefaultCityPage))
            {
                page = DefaultCityPage;
            }
            var cities = _cityRepository.GetCitiesToPage(search,page * NumberOfCityPerPage - NumberOfCityPerPage, NumberOfCityPerPage);
            CityPageModel result = new CityPageModel(cities.CityItems.Select(CityMapper.MapItemToModel).ToList(), GetCountPage(cities.TotalCities), page);
            return result;
        }

        public async Task RemoveCity(int id)
        {
            _cityRepository.Remove(await _cityRepository.GetById(id));
            await _cityRepository.Save();
        }

        public async Task UpdateCity(CityModel city)
        {
            _cityRepository.Update(CityMapper.MapModelToItem(city));
            await _cityRepository.Save();
        }

        public async Task<List<CityModel>> GetCountryForCities(List<CityModel> cityModels)
        {
            foreach (var t in cityModels)
            {
                t.Country = await GetCountry(t.CountryId);
            }

            return cityModels;
        }

        private async Task<CountryModel> GetCountry(int countryId)
        {
            return CountryMapper.MapItemToModel(await _countryRepository.GetById(countryId));
        }

        private int GetCountPage(int total)
        {
            if (total % NumberOfCityPerPage == 0)
            {
                return total / NumberOfCityPerPage;
            }
            return total / NumberOfCityPerPage + DefaultCityPage;
        }
    }
}
