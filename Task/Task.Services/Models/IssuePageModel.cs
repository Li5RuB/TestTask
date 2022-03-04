using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Services.Models
{
    public class IssuePageModel
    {
        public IssuePageModel(
            List<IssueModel> issueModels,
            List<TimeLogModel> timeLogModels,
            List<DatePageModel> dateTimes,
            int week,
            int year)
        {
            this.IssueModels = issueModels;
            this.TimeLogModels = timeLogModels;
            this.DateForPage = dateTimes;
            this.Week = week;
            this.Year = year;
        }

        public List<IssueModel> IssueModels { get; set; }

        public List<TimeLogModel> TimeLogModels { get; set; }

        public List<DatePageModel> DateForPage { get; set; }

        public int Week { get; set; }

        public int Year { get; set; }
    }
}
