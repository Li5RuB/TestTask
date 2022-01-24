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
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private const int defaultCityPage = 1;
        private const int numberOfCityPerPage = 8;

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

        public List<CityModel> GetCitiesByCountryId(int CountryId)
        {
            var cities = _cityRepository.GetCitiesByCountryId(CountryId);
            var result = cities.Select(x=>CityMapper.MapItemToModel(x)).ToList(); 
            return result;
        }

        public CityPageModel GetCityPageModel(int page, string search)
        {
            var cityPageModel = search == null ? GetByPage(page) : Search(search, page);
            return cityPageModel;
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
            for (int i = 0; i < cityModels.Count; i++)
            {
                cityModels[i].Country = await GetCountry(cityModels[i].CountryId);
            }
            return cityModels;
        }

        private async Task<CountryModel> GetCountry(int CountryId)
        {
            return CountryMapper.MapItemToModel(await _countryRepository.GetById(CountryId));
        }

        private int GetCountPage(int total)
        {
            if (total % numberOfCityPerPage == 0)
            {
                return total / numberOfCityPerPage;
            }
            return total / numberOfCityPerPage + defaultCityPage;
        }

        private CityPageModel Search(string search, int page)
        {
            var cities = _cityRepository.Search(search, page * numberOfCityPerPage - numberOfCityPerPage, numberOfCityPerPage);
            CityPageModel result = new CityPageModel(cities.CityItems.Select(x => CityMapper.MapItemToModel(x)).ToList(), GetCountPage(cities.TotalCities), page);
            return result;
        }

        private CityPageModel GetByPage(int page)
        {
            if (!(page > defaultCityPage))
            {
                page = defaultCityPage;
            }
            var cities = _cityRepository.GetCitiesToPage(page * numberOfCityPerPage - numberOfCityPerPage, numberOfCityPerPage);
            CityPageModel result = new CityPageModel(cities.CityItems.Select(x => CityMapper.MapItemToModel(x)).ToList(), GetCountPage(cities.TotalCities), page);
            return result;
        }
    }
}
