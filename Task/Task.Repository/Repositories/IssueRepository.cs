using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;
using TestTask.Repository.Models;

namespace TestTask.Repository.Repositories
{
    public class IssueRepository : BaseRepository<IssueItem>, IIssueRepository
    {
        private readonly ITimeLogRepository _timeLogRepository;

        public IssueRepository(
            ApplicationDbContext context, 
            ITimeLogRepository timeLogRepository) : base(context)
        {
            _timeLogRepository = timeLogRepository;
        }

        public List<IssueItem> GetIssuesByUserId(int id)
        {
            return GetAll().Where(x => x.UserId == id).ToList();
        }

        public IssueSearchResultModel GetIssueToPage(List<DateTime> dateForPage, int userId, int week, int year)
        {
            var issueItems = GetAll().Where(x => x.UserId == userId).ToList();
            return new IssueSearchResultModel() { IssueItems = issueItems };
        }
    }
}
