using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository.Items
{
    [Keyless]
    public class LastLoginStatisticsItem
    {
        public string CountryName { get; set; }

        public int UsersCount { get; set; }

        public DateTime LastLoginFromCountry { get; set; }
    }
}
