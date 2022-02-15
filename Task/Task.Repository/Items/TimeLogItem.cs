using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository.Items
{
    public class TimeLogItem
    {
        [Key]
        public int TimeLogId { get; set; }

        public int IssueId { get; set; }

        public DateTime DateLog { get; set; }

        public TimeSpan Time { get; set; }
    }
}
