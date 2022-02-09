using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class LastLoginStatisticsModel
    {
        public string CountryName { get; set; }

        public int UsersCount { get; set; }

        public DateTime LastLoginFromCountry { get; set; }
    }
}
