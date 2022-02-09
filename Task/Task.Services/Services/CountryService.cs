using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class CountryService : ICountryService
    {
        private const int NumberOfCountriesPerPage = 4;
        private const int DefaultCountryPage = 1;
        private readonly ICountryRepository _countryRepository;
        
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
            var result = countries.Select(CountryMapper.MapItemToModel).ToList();
            return result;
        }

        public async Task<CountryModel> GetById(int id)
        {
            return CountryMapper.MapItemToModel(await _countryRepository.GetById(id));
        }

        public CountryPageModel GetCountryPageModel(int page, string search)
        {
            if (!(page > DefaultCountryPage))
            {
                page = DefaultCountryPage;
            }
            var countries = _countryRepository.GetCountriesToPage(search, page * NumberOfCountriesPerPage - NumberOfCountriesPerPage, NumberOfCountriesPerPage);
            CountryPageModel result = new CountryPageModel(countries.CountryItems.Select(CountryMapper.MapItemToModel).ToList(), GetCountPage(countries.TotalCountries), page);
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
        
        private int GetCountPage(int total)
        {
            if (total % NumberOfCountriesPerPage == 0)
            {
                return total / NumberOfCountriesPerPage;
            }
            return total / NumberOfCountriesPerPage + DefaultCountryPage;
        }
    }
}
