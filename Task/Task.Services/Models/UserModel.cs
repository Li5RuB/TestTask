﻿using System;
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
        public string Lastname { get; set;}

        [Required]
        [EmailAddress(ErrorMessage = "invalid email") ]
        public string Email { get; set; }

        [Phone(ErrorMessage = "invalid phone")]
        public string Phone { get; set; }

        [StringLength(255)]
        public string Comments { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int TitleId { get; set; }

        public TitleModel Title { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int CityId { get; set; }

        public CityModel City { get; set; }
    }
}
