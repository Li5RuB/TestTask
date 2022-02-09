using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Mappers
{
    public static class CountryMapper
    {
        public static CountryModel MapItemToModel(CountryItem item)
        {
            return new CountryModel()
            {
                CountryId = item.CountryId,
                Name = item.Name,
                Description = item.Description,
            };
        }

        public static CountryItem MapModelToItem(CountryModel model)
        {
            return new CountryItem()
            {
                CountryId = model.CountryId,
                Name = model.Name,
                Description = model.Description,
            };
        }
    }
}
