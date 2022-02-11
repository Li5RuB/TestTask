using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public interface IIssueService
    {
        public Task<IssueModel> GetById(int id);

        public List<IssueModel> GetIssuesByUserId(int id);

        public Task CreateIssue(IssueModel issue);

        public Task RemoveIssue(int id);

        public Task UpdateIssue(IssueModel issue);
    }
}
