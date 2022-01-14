using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Services
{
    public interface ICityService
    {
        public IEnumerable<CityModel> GetAll();

        public Task<CityModel> GetById(int id);

        public IEnumerable<CityModel> GetUsers(Expression<Func<CityItem, bool>> expression);
    }
}
