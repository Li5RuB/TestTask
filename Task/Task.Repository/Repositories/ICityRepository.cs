using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Models;

namespace TestTask.Repository.Repositories
{
    public interface ICityRepository
    {
        public Task<CityItem> GetById(int id);

        public List<CityItem> GetCitiesByCountryId(int id);

        public CitiesSearchResultModel GetCitiesToPage(int skip, int take);

        public CitiesSearchResultModel Search(string search, int skip, int take);

        public void Create(CityItem user);

        public void Remove(CityItem user);

        public void Update(CityItem user);

        public Task Save();
    }
}
