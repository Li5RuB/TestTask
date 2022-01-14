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
        private readonly UnitOfWork unitOfWork;
        private readonly TitleMapper titleMapper;

        public TitleService(UnitOfWork unitOfWork, TitleMapper titleMapper)
        {
            this.unitOfWork = unitOfWork;
            this.titleMapper = titleMapper;
        }

        public IEnumerable<TitleModel> GetAll()
        {
            return this.titleMapper.MapItemToModelRange(this.unitOfWork.TitleRepository.GetAll());
        }

        public async Task<TitleModel> GetById(int id)
        {
            return titleMapper.MapItemToModel(await this.unitOfWork.TitleRepository.GetById(id));
        }
    }
}
