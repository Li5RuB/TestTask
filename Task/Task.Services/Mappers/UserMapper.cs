﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
{
    public class UserMapper : IMapper<UserItem, UserModel>
    {
        public UserModel MapItemToModel(UserItem item)
        {
            return new UserModel()
            {
                Id = item.Id,
                Firstname = item.Firstname,
                Lastname = item.Lastname,
                CityId = item.CityId,
                Comments = item.Comments,
                TitleId = item.TitleId,
                Email = item.Email,
                Phone = item.Phone
            };
        }

        public IEnumerable<UserModel> MapItemToModelRange(IEnumerable<UserItem> items)
        {
            var result = new List<UserModel>();
            foreach (var item in items)
            {
                result.Add(new UserModel()
                {
                    Id = item.Id,
                    Firstname = item.Firstname,
                    Lastname = item.Lastname,
                    CityId = item.CityId,
                    Comments = item.Comments,
                    TitleId = item.TitleId,
                    Email = item.Email,
                    Phone = item.Phone
                });
            }
            return result;
        }

        public UserItem MapModelToItem(UserModel model)
        {
            return new UserItem()
            {
                Id = model.Id,
                Firstname = model.Firstname,
                Lastname = model.Lastname,
                CityId = model.CityId,
                Comments = model.Comments,
                TitleId = model.TitleId,
                Email = model.Email,
                Phone = model.Phone
            };
        }

        public IEnumerable<UserItem> MapItemToModelRange(IEnumerable<UserModel> models)
        {
            var result = new List<UserItem>();
            foreach (var model in models)
            {
                result.Add(new UserItem()
                {
                    Id = model.Id,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    CityId = model.CityId,
                    Comments = model.Comments,
                    TitleId = model.TitleId,
                    Email = model.Email,
                    Phone = model.Phone
                });
            }
            return result;
        }
    }
}
