using System;
using ExploreCalifornia.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        [Route("")]
        public IActionResult Index() { return View(); }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var post = new Post { Title = "Something", Posted = DateTime.Now, Author = "Someone", Body = "Some body" };
            return View(post);
        }

        [HttpGet, Route("create")]
        public IActionResult Create() { return View(); }
        
        [HttpPost, Route("create")]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid) { return View(); }
            post.Author = "Alican Demirtas";
            post.Posted = DateTime.Now;
            return View();
        }
    }
}