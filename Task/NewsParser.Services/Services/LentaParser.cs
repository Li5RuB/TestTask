using HtmlAgilityPack;
using NewsParser.Common.Settings;
using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Services
{
    public class LentaParser : IParser
    {
        private readonly string Url;

        public LentaParser(IAppSettings appSettings)
        {
            Url = appSettings.LentaLink;
        }

        public NewsModel Parse()
        {
            return null;
        }
    }
}
