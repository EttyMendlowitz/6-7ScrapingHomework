using AngleSharp.Dom;
using AngleSharp.Html.Parser;
using Microsoft.AspNetCore.Http.Features;
using static System.Net.Mime.MediaTypeNames;

namespace _6_7ScrapingHomework
{
    public static class Scraper
    {

        public static List<ScrapedItem> GetScrapedItems()
        {
            var html = getHtml();
            return ParseHtml(html);
        }
        private static string getHtml()
        {
            var handler = new HttpClientHandler
            {
                AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate,
                UseCookies = true
            };

            using var client = new HttpClient(handler);

            var html = client.GetStringAsync("https://thelakewoodscoop.com/").Result;
            return html;
        }

        private static List<ScrapedItem> ParseHtml(string html)
        {
            var parser = new HtmlParser();
            var document = parser.ParseDocument(html);
            var classes = document.QuerySelectorAll(".td_module_flex");
            var items = new List<ScrapedItem>();

            foreach (var c in classes)
            {
                var item = new ScrapedItem();
                var title = c.QuerySelector(".entry-title.td-module-title");
                if (title != null)
                {
                    item.Title = title.TextContent;
                }

                var url = c.QuerySelector("a");

                if(url != null)
                {
                    item.Url = url.Attributes["href"].Value;
                }

                var text = c.QuerySelector(".td-excerpt");
                if (text != null)
                {
                    item.Text = title.TextContent;
                }

                var image = c.QuerySelector(".entry-thumb.td-thumb-css");
                if (image != null)
                {
                    item.Image = image.Attributes["data-img-url"].Value;
                }
                items.Add(item);
            }
            return items;

        }


    }
}
