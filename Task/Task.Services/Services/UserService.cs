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

        public async Task<UserModel> GetById(int id)
        {
            return UserMapper.MapItemToModel(await userRepository.GetById(id));
        }

        public IEnumerable<UserModel> GetByPage(int page)
        {
            if (!(page>1))
            {
                page = 1;
            }
            var users = userRepository.GetUsersToPage(page);
            var result = users.Select(x=>UserMapper.MapItemToModel(x));
            return result;
        }

        public int GetPageCount(string search = null)
        {
            var count = search==null?userRepository.GetCount():GetSearchCount(search);
            if (count%3==0)
            {
                return count / 3;
            }
            return count / 3 + 1;
        }

        private int GetSearchCount(string search)
        {
            return userRepository.GetSearchCount(i => i.Firstname.ToUpper().Contains(search.ToUpper()) || i.Lastname.ToUpper().Contains(search.ToUpper())
            || i.Email.ToUpper().Contains(search.ToUpper()) || i.Phone.ToUpper().Contains(search.ToUpper()));
        }

        public async System.Threading.Tasks.Task RemoveUser(int id)
        {
            userRepository.Remove(await userRepository.GetById(id));
        }

        public async System.Threading.Tasks.Task SaveChanges()
        {
            await userRepository.Save();
        }

        public IEnumerable<UserModel> Search(string search, int page)
        {
            var users = userRepository.Search(i => i.Firstname.ToUpper().Contains(search.ToUpper()) || i.Lastname.ToUpper().Contains(search.ToUpper())
            || i.Email.ToUpper().Contains(search.ToUpper()) || i.Phone.ToUpper().Contains(search.ToUpper()), page);
            var result = users.Select(x=>UserMapper.MapItemToModel(x)).ToList();
            return result;
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
