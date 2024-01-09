using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Data
    {
    public class BlogRazorDbContext : DbContext
        {
        public BlogRazorDbContext(DbContextOptions options) : base(options)
            {

            }


        public DbSet<BlogPost> BlogPosts { get; set; }
        }
    }
