using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Data
{
    /// <summary>
    /// Represents the database context for the BlogRazor application.
    /// </summary>
    public class BlogRazorDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogRazorDbContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public BlogRazorDbContext(DbContextOptions<BlogRazorDbContext> options) : base(options)
        {

        }

        /// <summary>
        /// Gets or sets the DbSet for storing BlogPosts in the database.
        /// </summary>
        public DbSet<BlogPost> BlogPosts { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for storing BlogPostLikes in the database.
        /// </summary>
        public DbSet<BlogPostLike> BlogPostLike { get; set; }

        /// <summary>
        /// Gets or sets the DbSet for storing BlogPostComments in the database.
        /// </summary>
        public DbSet<BlogPostComment> BlogPostComment { get; set; }
    }
}
