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
        private readonly ICountryRepository countryRepository; 
        public CountryService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }

        public IEnumerable<CountryModel> GetAll()
        {
            var countries = countryRepository.GetAllCountries();
            var result = countries.Select(x => CountryMapper.MapItemToModel(x)).ToList();
            return result;
        }

        public async Task<CountryModel> GetById(int id)
        {
            return CountryMapper.MapItemToModel(await countryRepository.GetById(id));
        }

    }
}
