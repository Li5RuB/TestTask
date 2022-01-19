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
            return new UserModel()
            {
                UserId = item.UserId,
                Firstname = item.Firstname,
                Lastname = item.Lastname,
                CityId = item.CityId,
                Comments = item.Comments,
                TitleId = item.TitleId,
                Email = item.Email,
                Phone = item.Phone
            };
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
                Phone = model.Phone
            };
        }
    }
}
