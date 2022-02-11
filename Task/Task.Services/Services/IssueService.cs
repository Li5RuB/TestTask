using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
{
    public class IssueService : IIssueService
    {
        private readonly IIssueRepository _issueRepository;

        public IssueService(IIssueRepository issueRepository)
        {
            _issueRepository = issueRepository;
        }

        public async Task CreateIssue(IssueModel issue)
        {
            _issueRepository.Create(IssueMapper.MapModelToItem(issue));
            await _issueRepository.Save();
        }

        public async Task<IssueModel> GetById(int id)
        {
            return IssueMapper.MapItemToModel(await _issueRepository.GetById(id));
        }

        public List<IssueModel> GetIssuesByUserId(int id)
        {
            return _issueRepository.GetIssuesByUserId(id).Select(IssueMapper.MapItemToModel).ToList();
        }

        public async Task RemoveIssue(int id)
        {
            _issueRepository.Remove(await _issueRepository.GetById(id));
            await _issueRepository.Save();
        }

        public async Task UpdateIssue(IssueModel issue)
        {
            _issueRepository.Update(IssueMapper.MapModelToItem(issue));
            await _issueRepository.Save();
        }
    }
}
