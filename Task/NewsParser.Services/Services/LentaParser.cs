using HtmlAgilityPack;
using NewsParser.Common.Settings;
using NewsParser.Services.Models;
using NewsParser.Common.Consts;
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

        public List<NewsModel> Parse()
        {
            var web = new HtmlWeb();
            var doc = web.Load(Url);
            var hotNews = GetNews(doc);
            var parsedNews = new List<NewsModel>();
            for (int i = 0; i < ParserConsts.NumberOfNewsForPars; i++)
            {
                string href;
                if (hotNews[i].Name.Contains("a"))
                {
                    href = hotNews[i].GetAttributeValue("href", "def");
                }
                else
                {
                    href = hotNews[i].Descendants("a").FirstOrDefault().GetAttributeValue("href", "def");
                }
                string newsUrl;
                if(!href.Contains("https"))
                    newsUrl = Url + href;
                else
                    newsUrl = href;
                var newsModel = GetNewsModel(web, newsUrl);
                parsedNews.Add(newsModel);
            }
            return parsedNews;
        }

        private static List<HtmlNode> GetNews(HtmlDocument doc)
        {
            var news = doc.DocumentNode.Descendants("div").FirstOrDefault(x => x.HasClass("topnews"));
            var a = news.Descendants().Where(x=>x.HasClass("topnews__column")).FirstOrDefault();
            return news.ChildNodes.ToList();
        }

        private static NewsModel GetNewsModel(HtmlWeb web, string newsUrl)
        {
            var newdoc = web.Load(newsUrl).DocumentNode.Descendants();
            var titleNews = GetTitleNews(newdoc,newsUrl);
            var textNews = GetTextNews(newdoc,newsUrl);
            var dateNews = GetDateNews(newdoc, newsUrl);
            return new NewsModel(titleNews, textNews, newsUrl, dateNews, "lenta");
        }

        private static DateTime GetDateNews(IEnumerable<HtmlNode> newdoc, string url)
        {
            var dateNewsText = newdoc
                            .FirstOrDefault(n => n.HasClass("topic-header__time"))
                            .InnerText.Split(' ')
                            .Where(c => c != "\n" && c != string.Empty && c != " ").ToArray();
            dateNewsText[0] = dateNewsText[0].Substring(0,5);
            return DateTime.Parse($"{dateNewsText[1]} {dateNewsText[2]} {dateNewsText[3]} {dateNewsText[0]}");
        }

        private static string GetTextNews(IEnumerable<HtmlNode> newdoc, string url)
        {
            var textNewsNodes = newdoc
                            .FirstOrDefault(n => n.HasClass("topic-body__content")).ChildNodes
                            .Where(n => n.Name.ToLower() == "p");
            return string.Join(' ',
                string.Join('\n',
                textNewsNodes.Where(n => n.InnerText != string.Empty)
                .Select(n => n.InnerText + "\n")).Split(' ').Take(30));
        }

        private static string GetTitleNews(IEnumerable<HtmlNode> newdoc, string url)
        {
            return newdoc
                .FirstOrDefault(n => n.HasClass("topic-header__title"))
                .InnerText;
        }
    }
}
