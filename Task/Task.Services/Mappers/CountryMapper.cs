using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Items;
using Task.Services.Models;

namespace Task.Services.Mappers
{
    public static class CountryMapper
    {
        public static CountryModel MapItemToModel(CountryItem item)
        {
            return new CountryModel()
            {
                CountryId = item.CountryId,
                Name = item.Name,
            };
        }

        public static CountryItem MapModelToItem(CountryModel model)
        {
            return new CountryItem()
            {
                CountryId = model.CountryId,
                Name = model.Name,
            };
        }
    }
}
