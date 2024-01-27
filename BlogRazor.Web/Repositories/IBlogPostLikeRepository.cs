using BlogRazor.Web.Models.Domain;

namespace BlogRazor.Web.Repositories
{
    /// <summary>
    /// Interface for managing blog post likes in the database.
    /// </summary>
    public interface IBlogPostLikeRepository
    {
        /// <summary>
        /// Gets the total number of likes for a specific blog post asynchronously.
        /// </summary>
        /// <param name="blogPostId">The unique identifier of the blog post.</param>
        /// <returns>The total number of likes for the specified blog post.</returns>
        Task<int> GetTotalLikesForBlog(Guid blogPostId);

        /// <summary>
        /// Adds a like for a specific blog post asynchronously.
        /// </summary>
        /// <param name="blogPostId">The unique identifier of the blog post.</param>
        /// <param name="userId">The unique identifier of the user who liked the blog post.</param>
        Task AddLikeForBlog(Guid blogPostId,Guid userId);

        /// <summary>
        /// Gets all likes for a specific blog post asynchronously.
        /// </summary>
        /// <param name="blogPostId">The unique identifier of the blog post.</param>
        /// <returns>A collection of blog post likes associated with the specified blog post.</returns>
        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);
    }
}
