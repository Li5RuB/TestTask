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
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        private readonly ICityRepository cityRepository;
        private readonly ICountryRepository countryRepository;
        private readonly ITitleRepository titleRepository;
        
        public UserService(IUserRepository userRepository, ICityRepository cityRepository, ICountryRepository countryRepository, ITitleRepository titleRepository)
        {
            this.userRepository = userRepository;
            this.cityRepository = cityRepository;
            this.countryRepository = countryRepository;
            this.titleRepository = titleRepository;
        }

        public void CreateUser(UserModel user)
        {
            userRepository.Create(UserMapper.MapModelToItem(user));
        }

        public IEnumerable<UserModel> GetAll()
        {
            return UserMapper.MapItemToModelRange(userRepository.GetAll());
        }

        public async Task<UserModel> GetById(int id)
        {
            return UserMapper.MapItemToModel(await userRepository.GetById(id));
        }

        public async Task<IEnumerable<UserModel>> GetByPage(int page)
        {
            if (!(page>1))
            {
                page = 1;
            }
            var usersmodel = UserMapper.MapItemToModelRange(userRepository.GetAll().Skip(page * 3 - 3).Take(3)).ToList();
            return await GetAllUserFields(usersmodel);
        }

        public int GetPageCount(IEnumerable<UserModel> users)
        {
            var count = users.Count();
            if (count%3==0)
            {
                return count / 3;
            }
            return count / 3 + 1;
        }

        public async System.Threading.Tasks.Task RemoveUser(int id)
        {
            userRepository.Remove(await userRepository.GetById(id));
        }

        public async System.Threading.Tasks.Task SaveChanges()
        {
            await userRepository.Save();
        }

        public IEnumerable<UserModel> Search(string search)
        {
            var userModels = UserMapper.MapItemToModelRange(userRepository.GetAll().Where(i=>i.Firstname.ToUpper().Contains(search.ToUpper())||i.Lastname.ToUpper().Contains(search.ToUpper())
            ||i.Email.ToUpper().Contains(search.ToUpper()) ||i.Phone.ToUpper().Contains(search.ToUpper())));
            return userModels.ToList();
        }

        public void UpdateUser(UserModel user)
        {
            userRepository.Update(UserMapper.MapModelToItem(user));
        }

        public async Task<IEnumerable<UserModel>> GetAllUserFields(List<UserModel> userModels)
        {
            for (int i = 0; i < userModels.Count(); i++)
            {
                userModels[i].City = CityMapper.MapItemToModel(await cityRepository.GetById(userModels[i].CityId));
                userModels[i].City.Country = CountryMapper.MapItemToModel(await countryRepository.GetById(userModels[i].City.CountryId));
                userModels[i].Title = TitleMapper.MapItemToModel(await titleRepository.GetById(userModels[i].TitleId));
            }
            return userModels;
        }
    }
}
