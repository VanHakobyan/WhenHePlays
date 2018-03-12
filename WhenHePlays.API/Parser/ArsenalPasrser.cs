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
        public async Task<string> GetContent()
        {
            var content = await _httpClient.GetStringAsync(url);
            document.LoadHtml(content);
            var article = document.DocumentNode.SelectSingleNode(".//article[@class='views-element-container']");
            var imgs = article.SelectNodes(".//img");
            foreach (var img in imgs)
            {
                img.Attributes["src"].Value = img.Attributes["src"].Value.Insert(0, "https://www.arsenal.com");
            }
            return article.OuterHtml;
        }
    }
}
