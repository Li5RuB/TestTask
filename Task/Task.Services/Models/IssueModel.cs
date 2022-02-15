using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class IssueModel
    {
        [Required]
        public int IssueId { get; set; }
        
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public int UserId { get; set; }
        
        [Required]
        public string UserEmail { get; set; }
    }
}
