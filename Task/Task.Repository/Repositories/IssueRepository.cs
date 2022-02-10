using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Data;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public class IssueRepository : BaseRepository<IssueItem>, IIssueRepository
    {
        public IssueRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
