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
        
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(UserModel user)
        {
            userRepository.CreateUser(UserMapper.MapModelToItem(user));
        }

        public IEnumerable<UserModel> GetAll()
        {
            return UserMapper.MapItemToModelRange(userRepository.GetAll());
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
            return UserMapper.MapItemToModelRange(userRepository.GetAll().Skip(page * 3 - 3).Take(3));
        }

        public int GetPageCount()
        {
            var count = userRepository.GetAll().Count();
            if (count%3==0)
            {
                return count / 3;
            }
            return count / 3 + 1;
        }

        public async System.Threading.Tasks.Task RemoveUser(int id)
        {
            userRepository.RemoveUser(await userRepository.GetById(id));
        }

        public async System.Threading.Tasks.Task SaveChanges()
        {
            await userRepository.Save();
        }

        public IEnumerable<UserModel> Search(string search)
        {
            return UserMapper.MapItemToModelRange(userRepository.GetAll().Where(i=>i.Firstname.Contains(search)||i.Lastname.Contains(search)
            ||i.Email.Contains(search)||i.Phone.Contains(search)));
        }

        public void UpdateUser(UserModel user)
        {
            userRepository.UpdateUser(UserMapper.MapModelToItem(user));
        }
    }
}
