using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Mappers
{
    public static class LastLoginStatisticsMapper
    {
        public static LastLoginStatisticsModel MapItemToModel(LastLoginStatisticsItem item)
        {
            return new LastLoginStatisticsModel()
            {
                CountryName = item.CountryName,
                UsersCount = item.UsersCount,
                LastLoginFromCountry = item.LastLoginFromCountry,
            };
        }
    }
}
