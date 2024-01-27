using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Repositories
{
    /// <summary>
    /// Repository for managing blog posts in the database.
    /// </summary>
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogRazorDbContext _blogRazorDbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostRepository"/> class.
        /// </summary>
        /// <param name="blogRazorDbContext">The database context for BlogRazor.</param>
        public BlogPostRepository(BlogRazorDbContext blogRazorDbContext)
        {
            this._blogRazorDbContext = blogRazorDbContext;
        }

        /// <summary>
        /// Adds a new blog post to the database asynchronously.
        /// </summary>
        /// <param name="blogPost">The blog post to be added.</param>
        /// <returns>The added blog post.</returns>
        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            // Add the blog post to the database
            await _blogRazorDbContext.BlogPosts.AddAsync(blogPost);

            // Save changes to the database
            await _blogRazorDbContext.SaveChangesAsync();

            // Return the added blog post
            return blogPost;
        }

        /// <summary>
        /// Deletes a blog post from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the blog post to be deleted.</param>
        /// <returns>True if the blog post is deleted successfully; otherwise, false.</returns>
        public async Task<bool> DeleteAsync(Guid id)
        {
            // Find the existing blog post by its ID
            var existingBlogPost = await _blogRazorDbContext.BlogPosts.FindAsync(id);

            // If the blog post exists, remove it from the database
            if (existingBlogPost != null)
            {
                _blogRazorDbContext.BlogPosts.Remove(existingBlogPost);
                await _blogRazorDbContext.SaveChangesAsync();
                return true; // Blog post deleted successfully
            }

            return false; // Blog post not found or deletion failed
        }

        /// <summary>
        /// Gets all blog posts from the database asynchronously.
        /// </summary>
        /// <returns>A collection of all blog posts in the database.</returns>
        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            // Retrieve all blog posts from the database
            return await _blogRazorDbContext.BlogPosts.ToListAsync();
        }

        /// <summary>
        /// Gets a specific blog post by its unique identifier from the database asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the blog post.</param>
        /// <returns>The blog post with the specified identifier.</returns>
        public async Task<BlogPost> GetAsync(Guid id)
        {
            // Retrieve a blog post by its ID from the database
            return await _blogRazorDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Gets a specific blog post by its heading from the database asynchronously.
        /// </summary>
        /// <param name="heading">The heading of the blog post.</param>
        /// <returns>The blog post with the specified heading.</returns>
        public async Task<BlogPost> GetAsync(string heading)
        {
            // Retrieve a blog post by its heading from the database
            return await _blogRazorDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Heading == heading);
        }

        /// <summary>
        /// Updates an existing blog post in the database asynchronously.
        /// </summary>
        /// <param name="blogPost">The updated blog post.</param>
        /// <returns>The updated blog post.</returns>
        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            // Find the existing blog post by its ID
            var existingBlogPost = await _blogRazorDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == blogPost.Id);

            // If the blog post exists, update its properties
            if (existingBlogPost != null)
            {
                existingBlogPost.Heading = blogPost.Heading;
                existingBlogPost.PageTitle = blogPost.PageTitle;
                existingBlogPost.Content = blogPost.Content;
                existingBlogPost.ShortDescription = blogPost.ShortDescription;
                existingBlogPost.PublishedDate = blogPost.PublishedDate;
                existingBlogPost.Author = blogPost.Author;
                existingBlogPost.Visible = blogPost.Visible;
            }

            // Save changes to the database
            await _blogRazorDbContext.SaveChangesAsync();

            // Return the updated blog post
            return existingBlogPost;
        }
    }
}
