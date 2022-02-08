using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Mappers
{
    public static class CountStatisticsMapper
    {
        public static CountStatisticsModel MapItemToModel(CountStatisticsItem item)
        {
            return new CountStatisticsModel()
            {
                CitiesCount = item.CitiesCount,
                CountriesCount = item.CountriesCount,
                UsersCount = item.UsersCount,
            };
        }
    }
}
