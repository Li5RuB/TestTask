using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class TimeLogRepository : BaseRepository<TimeLogItem>, ITimeLogRepository
    {
        public TimeLogRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<TimeLogItem> GetLogsByIsueeId(int id)
        {
            return GetAll().Where(x => x.IssueId == id).ToList();
        }

        public List<TimeLogItem> GetLogsToPage(List<DateTime> date, List<IssueItem> issueItems)
        {
            var issueIds = issueItems.Select(x => x.IssueId).ToArray();
            var timeLogItems = GetAll().Where(x => x.DateLog >= date[0] && x.DateLog <= date[6] && issueIds.Contains(x.IssueId)).ToList();
            return timeLogItems;
        }
    }
}
