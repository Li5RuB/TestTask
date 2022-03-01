using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public interface ITimeLogRepository
    {
        public Task<TimeLogItem> GetById(int id);

        public List<TimeLogItem> GetLogsByIsueeId(int id);

        public List<TimeLogItem> GetLogsToPage(DateTime FirstDate, DateTime LastDate, List<int> issueIds);

        public void Create(TimeLogItem log);

        public void Remove(TimeLogItem log);

        public void Update(TimeLogItem log);

        public Task Save();
    }
}
