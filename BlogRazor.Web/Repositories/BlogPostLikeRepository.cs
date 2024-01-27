using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Repositories
{
    /// <summary>
    /// Repository for managing blog post likes in the database.
    /// </summary>
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogRazorDbContext blogRazorDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostLikeRepository"/> class.
        /// </summary>
        /// <param name="blogRazorDbContext">The database context for BlogRazor.</param>
        public BlogPostLikeRepository(BlogRazorDbContext blogRazorDbContext)
        {
            this.blogRazorDbContext = blogRazorDbContext;
        }

        /// <summary>
        /// Adds a like for a specific blog post asynchronously.
        /// </summary>
        /// <param name="blogPostId">The unique identifier of the blog post.</param>
        /// <param name="userId">The unique identifier of the user who liked the blog post.</param>
        public async Task AddLikeForBlog(Guid blogPostId,Guid userId)
        {
            // Create a new BlogPostLike instance
            var like = new BlogPostLike
            {
                Id = Guid.NewGuid(),
                BlogPostId = blogPostId,
                UserId = userId
            };

            // Add the like to the database
            await blogRazorDbContext.BlogPostLike.AddAsync(like);

            // Save changes to the database
            await blogRazorDbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Gets all likes for a specific blog post asynchronously.
        /// </summary>
        /// <param name="blogPostId">The unique identifier of the blog post.</param>
        /// <returns>A collection of blog post likes associated with the specified blog post.</returns>
        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            // Retrieve all likes for the specified blog post from the database
            return await blogRazorDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        /// <summary>
        /// Gets the total number of likes for a specific blog post asynchronously.
        /// </summary>
        /// <param name="blogPostId">The unique identifier of the blog post.</param>
        /// <returns>The total number of likes for the specified blog post.</returns>
        public async Task<int> GetTotalLikesForBlog(Guid blogPostId)
        {
            // Count the total number of likes for the specified blog post from the database
            return await blogRazorDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
