using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Repositories
{
    public class BlogPostRepository : IBlogPostRepository
    {
        private readonly BlogRazorDbContext _blogRazorDbContext;

        public BlogPostRepository(BlogRazorDbContext blogRazorDbContext)
        {
            this._blogRazorDbContext = blogRazorDbContext;
        }

        public async Task<BlogPost> AddAsync(BlogPost blogPost)
        {
            await _blogRazorDbContext.BlogPosts.AddAsync(blogPost);
            await _blogRazorDbContext.SaveChangesAsync();
            return blogPost;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existingBlogPost = await _blogRazorDbContext.BlogPosts.FindAsync(id);

            if (existingBlogPost != null)
            {
                _blogRazorDbContext.BlogPosts.Remove(existingBlogPost);
                await _blogRazorDbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<BlogPost>> GetAllAsync()
        {
            return await _blogRazorDbContext.BlogPosts.ToListAsync();
        }

        public async Task<BlogPost> GetAsync(Guid id)
        {
            return await _blogRazorDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<BlogPost> GetAsync(string heading)
        {
            return await _blogRazorDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Heading == heading);
        }

        public async Task<BlogPost> UpdateAsync(BlogPost blogPost)
        {
            var existingBlogPost = await _blogRazorDbContext.BlogPosts.FirstOrDefaultAsync(x => x.Id == blogPost.Id);

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

            await _blogRazorDbContext.SaveChangesAsync();

            return existingBlogPost;
        }
    }
}
