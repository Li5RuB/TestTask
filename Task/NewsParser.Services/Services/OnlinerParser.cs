using HtmlAgilityPack;
using NewsParser.Common.Consts;
using NewsParser.Common.Settings;
using NewsParser.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NewsParser.Services.Services
{
    public class OnlinerParser : IParser
    {
        private readonly string Url;

        public OnlinerParser(IAppSettings appSettings)
        {
            Url = appSettings.OnlinerLink;
        }
        public List<NewsModel> Parse()
        {
            var web = new HtmlWeb();
            var doc = web.Load(Url);
            var hotNews = GetNews(doc);
            var newsModels = new List<NewsModel>();
            foreach (var item in hotNews)
            {
                var href = item.GetAttributeValue("href", "def");
                var newsUrl = Url + href;
                var newsModel = GetNewsModel(web, newsUrl);
                newsModels.Add(newsModel);
            }
            return newsModels;
        }

        private static List<HtmlNode> GetNews(HtmlDocument doc)
        {
            var newsHref = new List<HtmlNode>();
            var news = doc.DocumentNode.Descendants().Where(x => x.HasClass("news-tidings__item")).ToList();
            int counter = 0 ;
            while (newsHref.Count < 3)
            {
                var newsItem = news[counter].Descendants("a").FirstOrDefault();
                if (newsItem != null)
                {
                    newsHref.Add(newsItem);
                }
                counter++;
            }

            return newsHref;
        }

        private static NewsModel GetNewsModel(HtmlWeb web, string newsUrl)
        {
            var newdoc = web.Load(newsUrl).DocumentNode.Descendants();
            var titleNews = GetTitleNews(newdoc);
            var textNews = GetTextNews(newdoc);
            var dateNews = GetDateNews(newdoc);
            return new NewsModel(titleNews, textNews, newsUrl, dateNews, "onliner");
        }

        private static DateTime GetDateNews(IEnumerable<HtmlNode> newdoc)
        {
            var dateNewsText = newdoc
                            .FirstOrDefault(n => n.HasClass("news-header__time"))
                            .InnerText.Split(' ')
                            .Where(c => c != "\n" && c != string.Empty && c != " ").ToArray();
            return DateTime.Parse($"{dateNewsText[0]} {dateNewsText[1]} {dateNewsText[2]} {dateNewsText[4]}");
        }

        private static string GetTextNews(IEnumerable<HtmlNode> newdoc)
        {
            var textNewsNodes = newdoc
                            .FirstOrDefault(n => n.HasClass("news-text")).ChildNodes
                            .Where(n => n.Name.ToLower() == "p");
            return string.Join(' ',
                string.Join('\n',
                textNewsNodes.Where(n => n.InnerText != string.Empty)
                .Select(n => n.InnerText + "\n")).Split(' ').Take(30));
        }

        private static string GetTitleNews(IEnumerable<HtmlNode> newdoc)
        {
            return newdoc
                .FirstOrDefault(n => n.HasClass("news-header__title"))
                .ChildNodes.FirstOrDefault(n => n.Name.ToLower() == "h1").InnerText;
        }
    }
}