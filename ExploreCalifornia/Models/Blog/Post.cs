using System;

namespace ExploreCalifornia.Models.Blog
{
    public class Post
    {
        public string Title { get; set; }
        public DateTime Posted { get; set; }
        public string Author { get; set; }
        public string Body { get; set; }
    }
}