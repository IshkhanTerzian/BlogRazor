using BlogRazor.Web.Models.Domain;

namespace BlogRazor.Web.Repositories
{
    public interface IBlogPostRepository
    {
        Task<IEnumerable<BlogPost>> GetAllAsync();

        Task<BlogPost> GetAsync(Guid id);

        Task<BlogPost> GetAsync(string heading);

        Task<BlogPost> AddAsync(BlogPost blogPost);

        Task<BlogPost> UpdateAsync(BlogPost blogPost);

        Task<bool> DeleteAsync(Guid id);
    }
}
