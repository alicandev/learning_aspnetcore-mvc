using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return new ContentResult { Content = "Blog post." };
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var content = $"Seeing the blog post named \"{key}\" from {year}/{month}";
            return new ContentResult { Content = content };
        }
    }
}