using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Repository.Models;

namespace TestTask.Repository.Repositories
{
    public interface IIssueRepository
    {
        public Task<IssueItem> GetById(int id);

        public List<IssueItem> GetIssuesByUserId(int id);

        public IssueSearchResultModel GetIssueToPage(List<DateTime> dateForPage, int userId, int week, int year);

        public void Create(IssueItem issue);

        public void Remove(IssueItem issue);

        public void Update(IssueItem issue);

        public Task Save();
    }
}
