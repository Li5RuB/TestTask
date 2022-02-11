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

        public void Create(IssueItem user);

        public void Remove(IssueItem user);

        public void Update(IssueItem user);

        public Task Save();
    }
}
