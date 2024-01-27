using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Repositories
{
    /// <summary>
    /// Repository for managing blog post comments in the database.
    /// </summary>
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogRazorDbContext blogRazorDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostCommentRepository"/> class.
        /// </summary>
        /// <param name="blogRazorDbContext">The database context for BlogRazor.</param>
        public BlogPostCommentRepository(BlogRazorDbContext blogRazorDbContext)
        {
            this.blogRazorDbContext = blogRazorDbContext;
        }

        /// <summary>
        /// Adds a new blog post comment to the database asynchronously.
        /// </summary>
        /// <param name="blogPostComment">The blog post comment to be added.</param>
        /// <returns>The added blog post comment.</returns>
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            // Add the blog post comment to the database
            await blogRazorDbContext.BlogPostComment.AddAsync(blogPostComment);

            // Save changes to the database
            await blogRazorDbContext.SaveChangesAsync();

            // Return the added blog post comment
            return blogPostComment;
        }

        /// <summary>
        /// Gets all comments for a specific blog post asynchronously.
        /// </summary>
        /// <param name="blogPostId">The unique identifier of the blog post.</param>
        /// <returns>A collection of blog post comments associated with the specified blog post.</returns>
        public async Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId)
        {
            // Retrieve all comments for the specified blog post from the database
            return await blogRazorDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
