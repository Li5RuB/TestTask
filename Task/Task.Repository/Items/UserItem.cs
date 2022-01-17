using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Repository.Items
{
    public class UserItem
    {
        [Key]
        public int UserId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set;}
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public int TitleId { get; set; }

        public string Comments { get; set; }

        public int CityId { get; set; }
    }
}
