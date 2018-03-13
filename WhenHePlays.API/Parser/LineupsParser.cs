using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Parser
{
    public class LineupsParser
    {
        HttpClient _httpClient = new HttpClient();
        private const string teamName = "Ulsan";
        public async Task<string> GetLineups()
        {
            HtmlAgilityPack.HtmlDocument _document = new HtmlDocument();
            var flashscoreHtml = await _httpClient.GetStringAsync("http://www.flashscore.mobi/");
            _document.LoadHtml(flashscoreHtml);
            var allTodayScores = _document.DocumentNode.SelectSingleNode(".//div[@id='score-data']");
            var allMatches = allTodayScores.InnerHtml.Split("<br>");
            var arsenalMatch = allMatches.FirstOrDefault(x => x.Contains(teamName));
            _document.LoadHtml(arsenalMatch);
            var link = _document.DocumentNode.SelectSingleNode(".//a").Attributes["href"].Value.Insert(0, "http://www.flashscore.mobi/");
            var htmlArsenalPage = await _httpClient.GetStringAsync(link);
            _document.LoadHtml(htmlArsenalPage);
            var detailTabs = _document.DocumentNode.SelectSingleNode(".//p[@id='detail-tabs']");
            var a = detailTabs.SelectSingleNode(".//a");
            var htmlLineups = String.Empty;
            if (a.InnerText == "Lineups")
            {
                var urlLineups = a.Attributes["href"].Value.Insert(0, @"http://www.flashscore.mobi").Replace("s=1&amp;", "");
                htmlLineups = await _httpClient.GetStringAsync(urlLineups);
            }
            else
            {
                htmlLineups = htmlArsenalPage;
            }
            _document = new HtmlDocument();
            _document.LoadHtml(htmlLineups);
            var lineupsAll = _document.DocumentNode.SelectSingleNode(".//div[@id='detail-tab-content']").InnerHtml;
            return lineupsAll;
        }
    }
}
