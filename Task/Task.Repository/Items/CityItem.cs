using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository.Items
{
    public class CityItem
    {
        [Key]
        public int CityId { get; set; }

        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
