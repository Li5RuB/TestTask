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
        public CountryService(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
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

    }
}
