using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class UserService : IUserService
    {
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

        public List<UserModel> GetByPage(int page)
        {
            if (!(page>1))
            {
                page = 1;
            }
            var users = _userRepository.GetUsersToPage(page);
            var result = users.Select(x=>UserMapper.MapItemToModel(x)).ToList();
            return result;
        }

        public int GetPageCount(string search = null)
        {
            var count = search==null?_userRepository.GetCount():GetSearchCount(search);
            if (count%3==0)
            {
                return count / 3;
            }
            return count / 3 + 1;
        }

        private int GetSearchCount(string search)
        {
            return _userRepository.GetSearchCount(i => i.Firstname.ToUpper().Contains(search.ToUpper()) || i.Lastname.ToUpper().Contains(search.ToUpper())
            || i.Email.ToUpper().Contains(search.ToUpper()) || i.Phone.ToUpper().Contains(search.ToUpper()));
        }

        public async Task RemoveUser(int id)
        {
            _userRepository.Remove(await _userRepository.GetById(id));
            await _userRepository.Save();
        }

        public List<UserModel> Search(string search, int page)
        {
            var users = _userRepository.Search(i => i.Firstname.ToUpper().Contains(search.ToUpper()) || i.Lastname.ToUpper().Contains(search.ToUpper())
            || i.Email.ToUpper().Contains(search.ToUpper()) || i.Phone.ToUpper().Contains(search.ToUpper()), page);
            var result = users.Select(x=>UserMapper.MapItemToModel(x)).ToList();
            return result;
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
            var users = search == null ? GetByPage(page).ToList() : Search(search, page).ToList();
            var pageCount = GetPageCount(search);
            if (pageCount < page)
                page = 1;
            else if (page < 1)
                page = pageCount;
            return new UserPageModel(users, pageCount, page);
        }
    }
}
