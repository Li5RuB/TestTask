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
        private readonly IAppSettings _settings;

        public ProgramProcess(IEnumerable<IParser> parsers, IAppSettings settings)
        {
            _parsers = parsers.ToList();
            _settings = settings;
        }

        public IConfiguration Configuration { get; }

        public void Run(string arg)
        {
            if (arg == "parse")
            {
                foreach (var item in _parsers)
                {
                    item.Parse();
                }
            }
            else if (arg == "send")
            {

            }
            else
                return;
        }
    }
}
