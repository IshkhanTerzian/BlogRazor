using BlogRazor.Web.Models.Domain;

namespace BlogRazor.Web.Repositories
{
    public interface IBlogPostLikeRepository
    {
        Task<int> GetTotalLikesForBlog(Guid blogPostId);

        Task AddLikeForBlog(Guid blogPostId,Guid userId);

        Task<IEnumerable<BlogPostLike>> GetLikesForBlog(Guid blogPostId);
    }
}
