using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Repository.Repositories;
using Task.Services.Mappers;
using Task.Services.Models;

namespace Task.Services.Services
{
    public class CityService : ICityService
    {
        private readonly UnitOfWork unitOfWork;
        private readonly CityMapper cityMapper;

        public CityService(UnitOfWork unitOfWork, CityMapper cityMapper)
        {
            this.unitOfWork = unitOfWork;
            this.cityMapper = cityMapper;
        }

        public IEnumerable<CityModel> GetAll()
        {
            return this.cityMapper.MapItemToModelRange(this.unitOfWork.CityRepository.GetAll());
        }

        public async Task<CityModel> GetById(int id)
        {
            return this.cityMapper.MapItemToModel(await this.unitOfWork.CityRepository.GetById(id));
        }

        public IEnumerable<CityModel> GetUsers(Expression<Func<CityItem, bool>> expression)
        {
            return this.cityMapper.MapItemToModelRange(this.unitOfWork.CityRepository.GetUsers(expression));
        }
    }
}
