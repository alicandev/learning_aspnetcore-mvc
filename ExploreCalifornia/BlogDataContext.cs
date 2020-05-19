using ExploreCalifornia.Models.Blog;
using Microsoft.EntityFrameworkCore;

namespace ExploreCalifornia
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        public BlogDataContext (DbContextOptions options) 
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}