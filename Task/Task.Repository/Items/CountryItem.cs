using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository.Items
{
    public class CountryItem
    {
        [Key]
        public int CountryId { get; set; }

        public string Name { get; set; }

        public string Descriptions { get; set; }
    }
}
