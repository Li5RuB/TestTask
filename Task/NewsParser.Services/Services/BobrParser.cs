using HtmlAgilityPack;
using NewsParser.Common.Consts;
using NewsParser.Common.Settings;
using NewsParser.Repositories.Repositories;
using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Services
{
    public class BobrParser : IParser
    {
        private readonly string Url;

        public BobrParser(IAppSettings appSettings)
        {
            Url = appSettings.BobrLink;
        }

        public List<NewsModel> Parse()
        {
            var web = new HtmlWeb();
            var doc = web.Load(Url);
            var hotNews = GetNews(doc);
            var parsedNews = new List<NewsModel>();
            for (int i = 0; i < ParserConsts.NumberOfNewsForPars; i++)
            {
                var href = hotNews[i].GetAttributeValue("href", "def");
                var newsUrl = Url + href;
                var newsModel = GetNewsModel(web, newsUrl);
                parsedNews.Add(newsModel);
            }
            return parsedNews;
        }

        private static List<HtmlNode> GetNews(HtmlDocument doc)
        {
            var news = doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.HasClass("content-wrap__top_news"));
            var UrlElement = news.Descendants("a").ToList();
            return UrlElement;
        }

        private static NewsModel GetNewsModel(HtmlWeb web, string newsUrl)
        {
            var newdoc = web.Load(newsUrl).DocumentNode.Descendants();
            var titleNews = GetTitleNews(newdoc);
            var textNews = GetTextNews(newdoc);
            var dateNews = GetDateNews(newdoc);
            return new NewsModel(titleNews, textNews, newsUrl, dateNews, "bobr");
        }

        private static DateTime GetDateNews(IEnumerable<HtmlNode> newdoc)
        {
            var dateNewsText = newdoc
                            .FirstOrDefault(n => n.HasClass("null-share"))
                            .Descendants("p")
                            .FirstOrDefault()
                            .InnerText.Split(' ')
                            .Where(c => c != "\n" && c != string.Empty && c != " ").ToArray();
            return DateTime.Parse($"{dateNewsText[0]} {dateNewsText[1]} {dateNewsText[2]}");
        }

        private static string GetTextNews(IEnumerable<HtmlNode> newdoc)
        {
            var textNewsNodes = newdoc
                            .FirstOrDefault(n => n.HasClass("null-double-inner__right")).ChildNodes
                            .Where(n => n.Name.ToLower() == "p");
            return string.Join(' ',
                string.Join('\n',
                textNewsNodes.Where(n => n.InnerText != string.Empty)
                .Select(n => n.InnerText + "\n")).Split(' ').Take(30));
        }

        private static string GetTitleNews(IEnumerable<HtmlNode> newdoc)
        {
            return newdoc.FirstOrDefault(x=>x.HasClass("null-title")).Descendants("h1")
                .FirstOrDefault()
                .InnerText;
        }
    }
}

