using BlogRazor.Web.Models.Domain;

namespace BlogRazor.Web.Repositories
{
    public interface IBlogPostCommentRepository
    {
        Task<BlogPostComment> AddAsync(BlogPostComment blogPostComment);

        Task<IEnumerable<BlogPostComment>> GetAllAsync(Guid blogPostId);
    }
}
