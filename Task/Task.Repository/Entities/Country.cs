using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository.Entities
{
    public class Country
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<City> Cities { get; set; }
    }
}
