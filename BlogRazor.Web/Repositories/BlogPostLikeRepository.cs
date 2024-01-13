
using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogRazor.Web.Repositories
{
    public class BlogPostLikeRepository : IBlogPostLikeRepository
    {
        private readonly BlogRazorDbContext blogRazorDbContext;

        public BlogPostLikeRepository(BlogRazorDbContext blogRazorDbContext)
        {
            this.blogRazorDbContext = blogRazorDbContext;
        }

        public async Task AddLikeForBlog(Guid blogPostId,Guid userId)
        {
            var like = new BlogPostLike
            {
                Id = Guid.NewGuid(),
                BlogPostId = blogPostId,
                UserId = userId
            };

            await blogRazorDbContext.BlogPostLike.AddAsync(like);
            await blogRazorDbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId)
        {
            return await blogRazorDbContext.BlogPostLike.Where(x => x.BlogPostId == blogPostId).ToListAsync();
        }

        public async Task<int> GetTotalLikesForBlog(Guid blogPostId)
        {
            return await blogRazorDbContext.BlogPostLike.CountAsync(x => x.BlogPostId == blogPostId);
        }
    }
}
