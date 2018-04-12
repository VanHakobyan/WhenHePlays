using System;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Parser
{
    public class ArsenalPasrser
    {
        HttpClient _httpClient =new HttpClient();
        HtmlAgilityPack.HtmlDocument document=new HtmlDocument();
        private const string url = @"https://www.arsenal.com/";
        public async Task<string[]> GetContent()
        {
            var result = new string[4];
            var content = await _httpClient.GetStringAsync(url);
            document.LoadHtml(content);
            var article = document.DocumentNode.SelectSingleNode(".//article[@class='views-element-container']");
            var imgs = article.SelectNodes(".//figure//img");
            for (var i = 0; i < imgs.Count; i++)
            {
                result[i] = imgs[i].Attributes["src"].Value.Insert(0, "https://www.arsenal.com");
            }
            var teamNames = article.SelectNodes(".//div[@class='team-crest__name-value']");
            for (var i = 0; i < teamNames.Count; i++)
            {
                result[i + 2] = teamNames[i].InnerText.Trim(' ', '\n', '\r', '\t');
            }
            return result;
        }
    }
}
