using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Repositories
{
    public class BlogPostCommentRepository : IBlogPostCommentRepository
    {
        private readonly BlogRazorDbContext blogRazorDbContext;

        public BlogPostCommentRepository(BlogRazorDbContext blogRazorDbContext)
        {
            this.blogRazorDbContext = blogRazorDbContext;
        }
        public async Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment)
        {
            await blogRazorDbContext.BlogPostComment.AddAsync(blogPostComment);
            await blogRazorDbContext.SaveChangesAsync();
            return blogPostComment;
        }

        public async Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId)
        {
            return await blogRazorDbContext.BlogPostComment.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }
    }
}
