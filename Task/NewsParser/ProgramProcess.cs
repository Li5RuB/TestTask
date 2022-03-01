using Microsoft.Extensions.Configuration;
using NewsParser.Common.Enums;
using NewsParser.Common.Settings;
using NewsParser.Repositories.Repositories;
using NewsParser.Services.Mappers;
using NewsParser.Services.Models;
using NewsParser.Services.Services;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace NewsParser
{
    public class ProgramProcess
    {
        private readonly List<IParser> _parsers;
        private readonly INewsService _newsService;
        private readonly ISendService _sendService;
        private readonly IGeneratorService _generatorService;
        private readonly IUserRepository _userRepository;
        private readonly IAppSettings _appSettings;

        public ProgramProcess(IEnumerable<IParser> parsers, 
            INewsService newsService, 
            ISendService sendService, 
            IGeneratorService generatorService,
            IUserRepository userRepository,
            IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _userRepository = userRepository;
            _parsers = parsers.ToList();
            _newsService = newsService;
            _sendService = sendService;
            _generatorService = generatorService;
        }

        public void Run(string arg)
        {
            var selectedFunction = Enum.Parse<ConsoleArgs>(arg);
            if (selectedFunction == ConsoleArgs.Parse)
            {
                foreach (var item in _parsers)
                {
                    _newsService.CreateNewsModels(item.Parse());
                }
            }
            else if (selectedFunction == ConsoleArgs.Send)
            {
                var messages = GetMessages();
                _sendService.SendMessages(messages.ToList());
            }
            else
                return;
        }

        private ConcurrentStack<Message> GetMessages()
        {
            var messages = new ConcurrentStack<Message>();
            List<Thread> threads;
            PrepareThreads(messages, out threads);
            threads.ForEach(s => s.Start());
            threads.ForEach(thread => thread.Join());
            return messages;
        }

        private void PrepareThreads(ConcurrentStack<Message> messages, out List<Thread> threads)
        {
            var usersModels = _userRepository.GetUsers().Select(UserMapper.Map).ToList();
            var numberOfThreads = _appSettings.NumberOfThreads;
            threads = new List<Thread>();
            CreateThreads(usersModels,messages, numberOfThreads, threads);
        }

        private void CreateThreads(List<UserModel> usersModels,ConcurrentStack<Message> messages, int numberOfThreads, List<Thread> threads)
        {
            foreach (var users in GetPartsOfUsers(usersModels, numberOfThreads))
            {
                threads.Add(new Thread(t =>
                {
                    _generatorService.GenerateMessages(users,messages);
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
