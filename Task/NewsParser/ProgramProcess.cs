using Microsoft.Extensions.Configuration;
using NewsParser.Common.Settings;
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

        public ProgramProcess(IEnumerable<IParser> parsers, INewsService newsService, ISendService sendService)
        {
            _parsers = parsers.ToList();
            _newsService = newsService;
            _sendService = sendService;
        }

        public IConfiguration Configuration { get; }

        public void Run(string arg)
        {
            if (arg == "parse")
            {
                foreach (var item in _parsers)
                {
                    _newsService.AddRange(item.Parse());
                }
            }
            else if (arg == "send")
            {
                _sendService.SendMessages();
            }
            else
                return;
        }
    }
}
