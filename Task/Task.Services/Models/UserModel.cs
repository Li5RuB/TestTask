using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Services.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Comments { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int TitleId { get; set; }

        public TitleModel Title { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CityId { get; set; }

        public CityModel City { get; set; }
        
        public int RoleId { get; set; }
        
        public RoleModel Role { get; set; }
        
        public string Password { get; set; }

        public DateTime? LastLogin { get; set; }
    }
}
