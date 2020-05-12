using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class BlogController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return new ContentResult { Content = "Blog post." };
        }
    }
}