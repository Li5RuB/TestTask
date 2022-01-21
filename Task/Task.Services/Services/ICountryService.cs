﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface ICountryService
    {
        public List<CountryModel> GetAll();

        public Task<CountryModel> GetById(int id);

        public Task CreateCountry(CountryModel user);

        public Task RemoveCountry(int id);

        public Task UpdateCountry(CountryModel user);

        public CountryPageModel GetCountryPageModel(int page, string search);
    }
}
