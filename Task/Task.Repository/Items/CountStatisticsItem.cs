using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository.Items
{
    [Keyless]
    public class CountStatisticsItem
    {
        public int UsersCount { get; set; }

        public int CountriesCount { get; set; }

        public int CitiesCount { get; set; }

    }
}
