using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Data
    {
    public class BlogRazorDbContext : DbContext
        {
        public BlogRazorDbContext(DbContextOptions<BlogRazorDbContext> options) : base(options)
            {

            }


        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<BlogPostLike> BlogPostLike { get; set; }

        public DbSet<BlogPostComment> BlogPostComment { get; set; }
        }
    }
