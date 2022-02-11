using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Items;

namespace TestTask.Repository.Repositories
{
    public interface IIssueRepository
    {
        public Task<IssueItem> GetById(int id);

        public List<IssueItem> GetIssuesByUserId(int id);

        public void Create(IssueItem issue);

        public void Remove(IssueItem issue);

        public void Update(IssueItem issue);

        public Task Save();
    }
}
