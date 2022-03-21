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

        public List<TimeLogItem> GetLogsToPage(DateTime FirstDate, DateTime LastDate, List<int> issueIds)
        {
            var timeLogItems = GetAll().Where(x => x.DateLog >= FirstDate && x.DateLog <= LastDate && issueIds.Contains(x.IssueId)).ToList();
            return timeLogItems;
        }

        public List<TimeLogItem> GetLogsByDate(DateTime date)
        {
            return GetAll().Where(x=>x.DateLog.Date == date.Date).ToList();
        }

    }
}
