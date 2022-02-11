using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class IssueModel
    {
        public int IssueId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }
    }
}
