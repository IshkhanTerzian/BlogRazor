using BlogRazor.Web.Models.Domain;

namespace BlogRazor.Web.Repositories
{
    /// <summary>
    /// Interface for managing blog post comments in the database.
    /// </summary>
    public interface IBlogPostCommentRepository
    {
        /// <summary>
        /// Adds a new blog post comment to the database asynchronously.
        /// </summary>
        /// <param name="blogPostComment">The blog post comment to be added.</param>
        /// <returns>The added blog post comment.</returns>
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);

        /// <summary>
        /// Gets all comments for a specific blog post from the database asynchronously.
        /// </summary>
        /// <param name="blogPostId">The unique identifier of the blog post.</param>
        /// <returns>A collection of blog post comments associated with the specified blog post.</returns>
        Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId);
    }
}
