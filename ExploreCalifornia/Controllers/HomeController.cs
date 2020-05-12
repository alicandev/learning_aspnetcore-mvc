using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    public class HomeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return new ContentResult { Content = "Hello from a controller action in ASP.NET Core MVC!" };
        }
    }
}