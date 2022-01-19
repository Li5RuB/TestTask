﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Repository.Repositories;
using TestTask.Services.Mappers;
using TestTask.Services.Models;

namespace TestTask.Services.Services
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
            var titles = titleRepository.GetAllTitles();
            var result = titles.Select(x => TitleMapper.MapItemToModel(x)).ToList();
            return result;
        }

        public async Task<TitleModel> GetById(int id)
        {
            return TitleMapper.MapItemToModel(await titleRepository.GetById(id));
        }
    }
}
