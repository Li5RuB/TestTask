using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Models
{
    public class CitiesSearchResultModel
    {
        public CitiesSearchResultModel(List<CityItem> cities, int totalCities)
        {
            this.CityItems = cities;
            this.TotalCities = totalCities;
        }

        public List<CityItem> CityItems { get; set; }

        public int TotalCities { get; set; }
    }
}
