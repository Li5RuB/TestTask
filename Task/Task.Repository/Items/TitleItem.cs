using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository.Items
{
    public class TitleItem
    {
        [Key]
        public int TitleId { get; set; }

        public string Name{ get; set; }
    }
}
