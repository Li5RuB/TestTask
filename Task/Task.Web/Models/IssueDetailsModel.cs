using System.Collections.Generic;
using TestTask.Services.Models;

namespace TestTask.Web.Models
{
    public class IssueDetailsModel
    {
        public IssueDetailsModel(IssueModel issueModel, List<TimeLogModel> timeLogModels)
        {
            IssueModel = issueModel;
            TimeLogModels = timeLogModels;
        }

        public IssueModel IssueModel { get; set; }

        public List<TimeLogModel> TimeLogModels { get; set; }
    }
}
