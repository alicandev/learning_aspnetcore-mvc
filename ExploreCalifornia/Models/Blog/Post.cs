using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ExploreCalifornia.Models.Blog
{
    public class Post
    {
        private string _key;
        public string Key
        {
            get { return _key ??= Regex.Replace(Title.ToLower(), "[^a-z0-9]", "-"); }
            set { _key = value; }
        }

        public long Id { get; set; }
        
        [Required, StringLength(100, MinimumLength = 5, ErrorMessage = "ANANKE")]
        public string Title { get; set; }

        public DateTime Posted { get; set; }

        public string Author { get; set; }

        [Required, MinLength(100, ErrorMessage = "BABANKE")]
        public string Body { get; set; }
    }
}