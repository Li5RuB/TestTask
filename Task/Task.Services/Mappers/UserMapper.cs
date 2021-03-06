using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Mappers
{
    public static class UserMapper
    {
        public static UserModel MapItemToModel(UserItem item)
        {
            if (item != null)
            {
                var model = new UserModel()
                {
                    UserId = item.UserId,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    CityId = item.CityId,
                    Comments = item.Comments,
                    TitleId = item.TitleId,
                    Email = item.Email,
                    Phone = item.Phone,
                    Password = item.Password,
                    RoleId = item.RoleId,
                    LastLogin = item.LastLogin,
                };   
                return model;
            }
            return null;
        }

        public static UserItem MapModelToItem(UserModel model)
        {
            return new UserItem()
            {
                UserId = model.UserId,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                CityId = model.CityId,
                Comments = model.Comments,
                TitleId = model.TitleId,
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password,
                RoleId = model.RoleId,
                LastLogin = model.LastLogin,
            };
        }

        public static UserModel MapRegisterModelToModel(RegisterModel model)
        {
            return new UserModel()
            {
                UserId = model.UserId,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                CityId = model.CityId,
                Comments = model.Comments,
                TitleId = model.TitleId,
                Email = model.Email,
                Phone = model.Phone,
                Password = model.Password,
                RoleId = model.RoleId
            };
        }
    }
}
