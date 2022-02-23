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

        public List<Message> GenerateMessages()
        {
            Console.WriteLine("Start");
            var usersModels = _userRepository.GetUsers().Select(UserMapper.Map).ToList();
            var news = _newsService.GetModelsForSending();
            var messages = new ConcurrentStack<Message>();
            var numberOfThreads = _appSettings.NumberOfThreads;
            var threads = new List<Thread>();

            CreateThreads(usersModels, news, messages, numberOfThreads, threads);
            var a = Stopwatch.StartNew();
            threads.ForEach(thread => thread.Start());
            threads.ForEach(thread => thread.Join());
            a.Stop();
            Console.WriteLine(a.ElapsedTicks);
            return messages.ToList();
        }

        private void CreateThreads(List<UserModel> usersModels, List<NewsModel> news, ConcurrentStack<Message> messages, int numberOfThreads, List<Thread> threads)
        {
            foreach (var users in GetPartsOfUsers(usersModels, numberOfThreads))
            {
                threads.Add(new Thread(t =>
                {
                    foreach (var user in users)
                    {
                        var generator = _generatorFactory.CreateMessageGenerator(user, news);
                        var mess = generator.CreateMessage();
                        messages.Push(mess);
                    }
                }));
            }
        }

        private static List<List<UserModel>> GetPartsOfUsers(List<UserModel> users, int numberOfThreads)
        {
            var partLength = (int)Math.Ceiling(users.Count / (double)numberOfThreads);
            var partsOfUsers = Enumerable.Range(0, numberOfThreads).AsParallel()
                      .Select(i => users.Skip(i * partLength)
                                         .Take(partLength)
                                         .ToList())
                      .ToList();
            return partsOfUsers;
        }

    }
}
