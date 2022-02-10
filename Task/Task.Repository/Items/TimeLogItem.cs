using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Repository.Items
{
    public class TimeLogItem
    {
        public int TimeLogId { get; set; }

        public int IssueId { get; set; }

        public DateTime DateLog { get; set; }

        public DateTime Time { get; set; }
    }
}
