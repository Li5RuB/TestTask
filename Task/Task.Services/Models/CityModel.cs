using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class CityModel
    {
        public int CityId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }

        public CountryModel Country { get; set; }
    }
}
