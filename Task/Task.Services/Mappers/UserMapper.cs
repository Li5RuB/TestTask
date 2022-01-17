using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
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

        public static IEnumerable<UserModel> MapItemToModelRange(IEnumerable<UserItem> items)
        {
            var result = new List<UserModel>();
            foreach (var item in items)
            {
                result.Add(MapItemToModel(item));
            }
            return result;
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

        public static IEnumerable<UserItem> MapItemToModelRange(IEnumerable<UserModel> models)
        {
            var result = new List<UserItem>();
            foreach (var model in models)
            {
                result.Add(MapModelToItem(model));
            }
            return result;
        }
    }
}
