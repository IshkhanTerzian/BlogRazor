using BlogRazor.Web.Models.Domain;

namespace BlogRazor.Web.Repositories
{
    /// <summary>
    /// Interface for managing blog posts in the database.
    /// </summary>
    public interface IBlogPostRepository
    {
        /// <summary>
        /// Gets all blog posts from the database asynchronously.
        /// </summary>
        /// <returns>A collection of all blog posts in the database.</returns>
        Task<IEnumerable<BlogPost>> GetAllAsync();

        /// <summary>
        /// Gets a specific blog post by its unique identifier from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the blog post.</param>
        /// <returns>The blog post with the specified identifier.</returns>
        Task<BlogPost> GetAsync(Guid id);

        /// <summary>
        /// Gets a specific blog post by its heading from the database asynchronously.
        /// </summary>
        /// <param name="heading">The heading of the blog post.</param>
        /// <returns>The blog post with the specified heading.</returns>
        Task<BlogPost> GetAsync(string heading);

        /// <summary>
        /// Adds a new blog post to the database asynchronously.
        /// </summary>
        /// <param name="blogPost">The blog post to be added.</param>
        /// <returns>The added blog post.</returns>
        Task<BlogPost> AddAsync(BlogPost blogPost);

        /// <summary>
        /// Updates an existing blog post in the database asynchronously.
        /// </summary>
        /// <param name="blogPost">The updated blog post.</param>
        /// <returns>The updated blog post.</returns>
        Task<BlogPost> UpdateAsync(BlogPost blogPost);

        /// <summary>
        /// Deletes a blog post from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the blog post to be deleted.</param>
        /// <returns>True if the blog post is deleted successfully; otherwise, false.</returns>
        Task<bool> DeleteAsync(Guid id);
    }
}
