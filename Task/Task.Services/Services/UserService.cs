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
        private readonly UnitOfWork unitOfWork;
        private readonly UserMapper userMapper; 
        
        public UserService(UnitOfWork unitOfWork, UserMapper userMapper)
        {
            this.unitOfWork = unitOfWork;
            this.userMapper = userMapper;
        }

        public void CreateUser(UserModel user)
        {
            this.unitOfWork.UserRepository.CreateUser(userMapper.MapModelToItem(user));
        }

        public IEnumerable<UserModel> GetAll()
        {
            return userMapper.MapItemToModelRange(unitOfWork.UserRepository.GetAll());
        }

        public async Task<UserModel> GetById(int id)
        {
            return userMapper.MapItemToModel(await unitOfWork.UserRepository.GetById(id));
        }

        public IEnumerable<UserModel> GetByPage(int page)
        {
            if (!(page>1))
            {
                page = 1;
            }
            return userMapper.MapItemToModelRange(unitOfWork.UserRepository.GetAll().Skip(page * 3 - 3).Take(3));
        }

        public int GetPageCount()
        {
            var count = unitOfWork.UserRepository.GetAll().Count();
            if (count%3==0)
            {
                return count / 3;
            }
            return count / 3 + 1;
        }

        public IEnumerable<UserModel> GetUsers(Expression<Func<UserItem, bool>> expression)
        {
            return userMapper.MapItemToModelRange(unitOfWork.UserRepository.GetUsers(expression));
        }

        public void RemoveUser(UserModel user)
        {
            unitOfWork.UserRepository.RemoveUser(userMapper.MapModelToItem(user));
        }

        public async System.Threading.Tasks.Task SaveChanges()
        {
            await unitOfWork.Save();
        }

        public IEnumerable<UserModel> Search(string search)
        {
            return userMapper.MapItemToModelRange(unitOfWork.UserRepository.GetUsers(i=>i.Firstname.Contains(search)||i.Lastname.Contains(search)
            ||i.Email.Contains(search)||i.Phone.Contains(search)));
        }

        public void UpdateUser(UserModel user)
        {
            unitOfWork.UserRepository.UpdateUser(userMapper.MapModelToItem(user));
        }
    }
}
