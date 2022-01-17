using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Repository.Repositories;
using Task.Services.Mappers;
using Task.Services.Models;

namespace Task.Services.Services
{
    public class TitleService : ITitleService
    {
        private readonly ITitleRepository titleRepository;

        public TitleService(ITitleRepository titleRepository)
        {
            this.titleRepository = titleRepository;
        }

        public IEnumerable<TitleModel> GetAll()
        {
            return TitleMapper.MapItemToModelRange(titleRepository.GetAll());
        }

        public async Task<TitleModel> GetById(int id)
        {
            return TitleMapper.MapItemToModel(await titleRepository.GetById(id));
        }
    }
}
