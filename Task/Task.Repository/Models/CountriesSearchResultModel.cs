using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Models
{
    public class CountriesSearchResultModel
    {
        public CountriesSearchResultModel(List<CountryItem> countries, int totalCountries)
        {
            this.CountryItems = countries;
            this.TotalCountries = totalCountries;
        }

        public List<CountryItem> CountryItems { get; set; }

        public int TotalCountries { get; set; }
    }
}
