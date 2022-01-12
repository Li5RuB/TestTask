using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository.Items
{
    public class CountryItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<CityItem> Cities { get; set; }
    }
}
