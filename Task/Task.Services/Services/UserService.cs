using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestTask.Repository.Models;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class UserService : IUserService
    {
        private const int NumberOfUsersPerPage = 3;
        private const int DefaultUserPage = 1;
        private readonly IUserRepository _userRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITitleRepository _titleRepository;
        
        public UserService(IUserRepository userRepository, 
            ICityRepository cityRepository, 
            ICountryRepository countryRepository, 
            ITitleRepository titleRepository)
        {
            _userRepository = userRepository;
            _cityRepository = cityRepository;
            _countryRepository = countryRepository;
            _titleRepository = titleRepository;
        }
        
        public async Task CreateUser(UserModel user)
        {
            _userRepository.Create(UserMapper.MapModelToItem(user));
            await _userRepository.Save();
        }
        
        public async Task<UserModel> GetById(int id)
        {
            return UserMapper.MapItemToModel(await _userRepository.GetById(id));
        }
        
        public async Task RemoveUser(int id)
        {
            _userRepository.Remove(await _userRepository.GetById(id));
            await _userRepository.Save();
        }
        
        public async Task UpdateUser(UserModel user)
        {
            _userRepository.Update(UserMapper.MapModelToItem(user));
            await _userRepository.Save();
        }
        
        public async Task<List<UserModel>> GetAllUserFields(List<UserModel> userModels)
        {
            for (int i = 0; i < userModels.Count(); i++)
            {
                userModels[i].City = CityMapper.MapItemToModel(await _cityRepository.GetById(userModels[i].CityId));
                userModels[i].City.Country = CountryMapper.MapItemToModel(await _countryRepository.GetById(userModels[i].City.CountryId));
                userModels[i].Title = TitleMapper.MapItemToModel(await _titleRepository.GetById(userModels[i].TitleId));
            }
            return userModels;
        }
        
        public async Task<UserPageModel> GetUserPageModel(UserPageModel model)
        {
            model.CurrentPage = model.CurrentPage == 0 ? 1 : model.CurrentPage;
            var userPageModel = GetByPage(model);
            await CreateUserPageModel(model, userPageModel);
            return userPageModel;
        }

        private async Task CreateUserPageModel(UserPageModel model, UserPageModel userPageModel)
        {
            userPageModel.UserModels = await GetAllUserFields(userPageModel.UserModels);
            userPageModel.Search = model.Search;
            userPageModel.Sort = model.Sort;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);
            return UserMapper.MapItemToModel(user);
        }
        
        private UserPageModel GetByPage(UserPageModel model)
        {
            if (!(model.CurrentPage > DefaultUserPage))
            {
                model.CurrentPage = DefaultUserPage;
            }
            var skip = model.CurrentPage * NumberOfUsersPerPage - NumberOfUsersPerPage;
            var modelForSearch = new ModelForSearch(skip, NumberOfUsersPerPage, model.Sort, model.Search);
            var users = _userRepository.GetUsersToPage(modelForSearch);
            var userModels = users.UserItems.Select(UserMapper.MapItemToModel).ToList();
            var count = GetCountPage(users.TotalUsers);
            var result = new UserPageModel(userModels, count, model.CurrentPage);
            return result;
        }
        
        private int GetCountPage(int total)
        {
            if (total % NumberOfUsersPerPage == 0)
            {
                return total / NumberOfUsersPerPage;
            }
            return total / NumberOfUsersPerPage + DefaultUserPage;
        }
    }
}
