using System;
using System.ComponentModel.DataAnnotations;

namespace ExploreCalifornia.Models.Blog
{
    public class Post
    {
        [Required]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "The length of the title must be between 5 and 100 characters long.")]
        public string Title { get; set; }

        public DateTime Posted { get; set; }

        public string Author { get; set; }

        [Required]
        [MinLength(100, ErrorMessage = "ananke")]
        public string Body { get; set; }
    }
}