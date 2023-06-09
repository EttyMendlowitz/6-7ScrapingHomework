using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _6_7ScrapingHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScrapingController : ControllerBase
    {
        [Route("getItems")]
        [HttpGet]
        public List<ScrapedItem> getItems()
        {
             var items =  Scraper.GetScrapedItems();
            return items;
        }
    }
}
