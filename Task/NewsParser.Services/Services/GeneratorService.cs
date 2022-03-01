using NewsParser.Common.Settings;
using NewsParser.Repositories.Repositories;
using NewsParser.Services.Mappers;
using NewsParser.Services.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace NewsParser.Services.Services
{
    public class GeneratorService : IGeneratorService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAppSettings _appSettings;
        private readonly INewsService _newsService;
        private readonly IGeneratorFactory _generatorFactory;

        public GeneratorService(
            IUserRepository userRepository,
            IAppSettings appSettings,
            INewsService newsService, 
            IGeneratorFactory generatorFactory)
        {
            _userRepository = userRepository;
            _appSettings = appSettings;
            _newsService = newsService;
            _generatorFactory = generatorFactory;
        }

        public List<Message> GenerateMessages(List<UserModel> userModels,ConcurrentStack<Message> messages)
        {
            var news = _newsService.GetModelsForSending();
            foreach (var user in userModels)
            {
                var generator = _generatorFactory.CreateMessageGenerator(user.RoleName);
                var mess = generator.CreateMessage(news, user);
                messages.Push(mess);
            }
            return messages.ToList();
        }
    }
}
