using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Models;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class UserService : IUserService
    {
        private const int numberOfUsersPerPage = 3;
        private const int defaultUserPage = 1;
        private readonly IUserRepository _userRepository;
        private readonly ICityRepository _cityRepository;
        private readonly ICountryRepository _countryRepository;
        private readonly ITitleRepository _titleRepository;
        
        public UserService(IUserRepository userRepository, ICityRepository cityRepository, ICountryRepository countryRepository, ITitleRepository titleRepository)
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

        public UserPageModel GetUserPageModel(int page, string search)
        {
            var userPageModel = search == null ? GetByPage(page): Search(search, page);
            return userPageModel;
        }

        private UserPageModel GetByPage(int page)
        {
            if (!(page > defaultUserPage))
            {
                page = defaultUserPage;
            }
            var users = _userRepository.GetUsersToPage(page * numberOfUsersPerPage - numberOfUsersPerPage, numberOfUsersPerPage);
            UserPageModel result = new UserPageModel(users.UserItems.Select(x => UserMapper.MapItemToModel(x)).ToList(), GetCountPage(users.TotalUsers), page);
            return result;
        }

        private UserPageModel Search(string search, int page)
        {
            var users = _userRepository.Search(search, page * numberOfUsersPerPage - numberOfUsersPerPage, numberOfUsersPerPage);
            UserPageModel result = new UserPageModel(users.UserItems.Select(x => UserMapper.MapItemToModel(x)).ToList(), GetCountPage(users.TotalUsers), page);
            return result;
        }

        private int GetCountPage(int total)
        {
            if (total % numberOfUsersPerPage == 0)
            {
                return total / numberOfUsersPerPage;
            }
            return total / numberOfUsersPerPage + defaultUserPage;
        }
    }
}
