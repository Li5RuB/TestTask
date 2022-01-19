using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Repository.Repositories;
using Task.Services.Mappers;
using Task.Services.Models;

namespace Task.Services.Services
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
            var countryModels = new List<CountryModel>();
            foreach (var item in countryRepository.GetAll())
            {
                countryModels.Add(CountryMapper.MapItemToModel(item));
            }
            return countryModels;
        }

        public async Task<CountryModel> GetById(int id)
        {
            return CountryMapper.MapItemToModel(await countryRepository.GetById(id));
        }

    }
}
