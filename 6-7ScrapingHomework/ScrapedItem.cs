using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace _6_7ScrapingHomework
{
    public class ScrapedItem
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string Comments { get; set; }
    }
}
