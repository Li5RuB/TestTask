using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Models;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface IIssueService
    {
        public Task<IssueModel> GetById(int id);

        public List<IssueModel> GetIssuesByUserId(int id);

        public IssuePageModel GetIssuesToPage(int week, int year, int userId);

        public Task CreateIssue(IssueModel issue);

        public Task RemoveIssue(int id);

        public Task UpdateIssue(IssueModel issue);

        public Task CloseIssue(int id);
    }
}
