using Microsoft.Extensions.Configuration;
using NewsParser.Services;
using NewsParser.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            }
            else if (arg == "send")
            {

            }
            else
                return;
        }
    }
}
