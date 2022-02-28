using Microsoft.Extensions.Configuration;
using NewsParser.Common.Settings;
using NewsParser.Enums;
using NewsParser.Services.Services;
using System.Collections.Generic;
using System.Linq;

namespace NewsParser
{
    public class ProgramProcess
    {
        private readonly List<IParser> _parsers;
        private readonly INewsService _newsService;
        private readonly ISendService _sendService;
        private readonly IGeneratorService _generatorService;

        public ProgramProcess(IEnumerable<IParser> parsers, INewsService newsService, ISendService sendService, IGeneratorService generatorService)
        {
            _parsers = parsers.ToList();
            _newsService = newsService;
            _sendService = sendService;
            _generatorService = generatorService;
        }

        public IConfiguration Configuration { get; }

        public void Run(string arg)
        {
            if (arg == ConsoleArgs.parse.ToString())
            {
                foreach (var item in _parsers)
                {
                    _newsService.CreateNewsModels(item.Parse());
                }
            }
            else if (arg == ConsoleArgs.send.ToString())
            {
                var messages = _generatorService.GenerateMessages();
                _sendService.SendMessages(messages);
            }
            else
                return;
        }
    }
}
