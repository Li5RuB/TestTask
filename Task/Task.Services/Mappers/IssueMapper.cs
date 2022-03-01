using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;
using TestTask.Services.Models;

namespace TestTask.Services.Mappers
{
    public static class IssueMapper
    {
        public static IssueModel MapItemToModel(IssueItem issueItem)
        {
            return new IssueModel()
            {
                IssueId = issueItem.IssueId,
                UserId = issueItem.UserId,
                Name = issueItem.Name,
                Description = issueItem.Description,
                IsClosed = issueItem.IsClosed,
            };
        } 

        public static IssueItem MapModelToItem(IssueModel issueModel)
        {
            return new IssueItem()
            {
                IssueId = issueModel.IssueId,
                UserId = issueModel.UserId,
                Name = issueModel.Name,
                Description = issueModel.Description,
                IsClosed = issueModel.IsClosed,
            };
        }
    }
}
