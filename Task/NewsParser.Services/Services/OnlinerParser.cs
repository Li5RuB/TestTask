using HtmlAgilityPack;
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
        public NewsModel Parse()
        {
            var web = new HtmlWeb();
            var doc = web.Load(Url);
            var hotNews = GetNews(doc);
            var href = hotNews.GetAttributeValue("href", "def");
            var newsUrl = Url + href;
            var newsModel = GetNewsModel(web, newsUrl);
            Console.WriteLine(newsModel.Title + "\n" + newsModel.BriefContext + "\n" + newsModel.Date + "\n" + newsModel.Url);
            return newsModel;
        }

        private static HtmlNode GetNews(HtmlDocument doc)
        {
            return doc.DocumentNode.Descendants()
                            .FirstOrDefault(n => n.HasClass("news-tidings__item"))
                            .ChildNodes.Descendants()
                            .FirstOrDefault(x => x.HasClass("news-tidings__stub") || x.HasClass("news-tiles__stub"));
        }

        private static NewsModel GetNewsModel(HtmlWeb web, string newsUrl)
        {
            var newdoc = web.Load(newsUrl).DocumentNode.Descendants();
            var titleNews = GetTitleNews(newdoc);
            var textNews = GetTextNews(newdoc);
            var dateNews = GetDateNews(newdoc);
            return new NewsModel(titleNews, textNews, newsUrl, dateNews, "Onliner");
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