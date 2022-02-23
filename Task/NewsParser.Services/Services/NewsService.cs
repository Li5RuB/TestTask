using NewsParser.Common.Settings;
using NewsParser.Repositories.Repositories;
using NewsParser.Services.Mappers;
using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Services
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepository;
        private readonly IAppSettings _appSettings;

        public NewsService(INewsRepository newsRepository, IAppSettings appSettings)
        {
            _newsRepository = newsRepository;
            _appSettings = appSettings;
        }

        public void AddRange(List<NewsModel> newsModels)
        {
            foreach (var item in newsModels)
            {
                _newsRepository.Create(NewsMapper.MapModelToItem(item));
            }
        }

        public List<NewsModel> GetModelsForSending()
        {
            var newsModels = new List<NewsModel>();
            foreach (var item in _appSettings.SitesForPars)
            {
                newsModels.Add(NewsMapper.MapItemToModel(_newsRepository.GetLastNewsByType(item)));
            }
            return newsModels;
        }
    }
}
