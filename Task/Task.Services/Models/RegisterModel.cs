using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TestTask.Services.Models
{
    public class RegisterModel
    {
        public int UserId { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public int CityId { get; set; }
        
        public string Comments { get; set; }
        [Required]
        public int TitleId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; } = 1;
    }
}