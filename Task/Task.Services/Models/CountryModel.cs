using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class CountryModel
    {
        public int CountryId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}
