using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private const int numberOfCountriesPerPage = 4;
        private const int defaultCountryPage = 1;
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task CreateCountry(CountryModel user)
        {
            _countryRepository.Create(CountryMapper.MapModelToItem(user));
            await _countryRepository.Save();
        }

        public List<CountryModel> GetAll()
        {
            var countries = _countryRepository.GetAllCountries();
            var result = countries.Select(x => CountryMapper.MapItemToModel(x)).ToList();
            return result;
        }

        public async Task<CountryModel> GetById(int id)
        {
            return CountryMapper.MapItemToModel(await _countryRepository.GetById(id));
        }

        public CountryPageModel GetCountryPageModel(int page, string search)
        {
            var countryPageModel = search == null ? GetByPage(page) : Search(search, page);
            return countryPageModel;
        }

        private CountryPageModel Search(string search, int page)
        {
            var countries = _countryRepository.Search(search, page * numberOfCountriesPerPage - numberOfCountriesPerPage, numberOfCountriesPerPage);
            CountryPageModel result = new CountryPageModel(countries.CountryItems.Select(x => CountryMapper.MapItemToModel(x)).ToList(), GetCountPage(countries.TotalCountries), page);
            return result;
        }

        private int GetCountPage(int total)
        {
            if (total % numberOfCountriesPerPage == 0)
            {
                return total / numberOfCountriesPerPage;
            }
            return total / numberOfCountriesPerPage + defaultCountryPage;
        }

        private CountryPageModel GetByPage(int page)
        {
            if (!(page > defaultCountryPage))
            {
                page = defaultCountryPage;
            }
            var countries = _countryRepository.GetCountriesToPage(page * numberOfCountriesPerPage - numberOfCountriesPerPage, numberOfCountriesPerPage);
            CountryPageModel result = new CountryPageModel(countries.CountryItems.Select(x => CountryMapper.MapItemToModel(x)).ToList(), GetCountPage(countries.TotalCountries), page);
            return result;
        }

        public async Task RemoveCountry(int id)
        {
            _countryRepository.Remove(await _countryRepository.GetById(id));
            await _countryRepository.Save();
        }

        public async Task UpdateCountry(CountryModel user)
        {
            _countryRepository.Update(CountryMapper.MapModelToItem(user));
            await _countryRepository.Save();
        }
    }
}
