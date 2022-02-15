using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Models
{
    public class IssueSearchResultModel
    {
        public IssueSearchResultModel(
            List<IssueItem> issueItems, 
            List<TimeLogItem> timeLogItems)
        {
            this.IssueItems = issueItems;
            this.TimeLogItems = timeLogItems;
        }

        public List<IssueItem> IssueItems { get; set; }

        public List<TimeLogItem> TimeLogItems { get; set; }
    }
}