using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository.Items
{
    public class UserItem
    {
        [Key]
        public int UserId { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }
        
        public string Email { get; set; }

        public string Phone { get; set; }

        public int TitleId { get; set; }

        public string Comments { get; set; }

        public int CityId { get; set; }
        
        public string Password { get; set; }
        
        public int RoleId { get; set; }
      
        public DateTime? LastLogin { get; set; }
    }
}
