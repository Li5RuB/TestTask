using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Mappers
{
    public static class TimeLogMapper
    {
        public static TimeLogModel MapItemToModel(TimeLogItem item)
        {
            return new TimeLogModel()
            {
                TimeLogId = item.TimeLogId,
                IssueId = item.IssueId,
                Time = item.Time,
                DateLog = item.DateLog,
            };
        }

        public static TimeLogItem MapModelToItem(TimeLogModel model)
        {
            return new TimeLogItem()
            {
                TimeLogId = model.TimeLogId,
                IssueId = model.IssueId,
                Time = model.Time,
                DateLog = model.DateLog,
            };
        }
    }
}
