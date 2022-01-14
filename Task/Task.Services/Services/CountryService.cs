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
        private readonly UnitOfWork unitOfWork;
        private readonly CountryMapper countryMapper;
        private readonly CityMapper cityMapper;

        public CountryService(UnitOfWork unitOfWork, CountryMapper countryMapper, CityMapper cityMapper)
        {
            this.unitOfWork = unitOfWork;
            this.countryMapper = countryMapper;
            this.cityMapper = cityMapper;
        }

        public IEnumerable<CountryModel> GetAll()
        {
            return this.countryMapper.MapItemToModelRange(this.unitOfWork.CountryRepository.GetAll());
        }

        public async Task<CountryModel> GetById(int id)
        {
            return this.countryMapper.MapItemToModel(await this.unitOfWork.CountryRepository.GetById(id));
        }

        public IEnumerable<CityModel> GetCities(int id)
        {
            return this.cityMapper.MapItemToModelRange(this.unitOfWork.CountryRepository.GetCities(id));
        }
    }
}
