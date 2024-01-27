using BlogRazor.Web.Models.ViewModels;
using BlogRazor.Web.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BlogRazor.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogPostLikeController : Controller
    {
        private readonly IBlogPostLikeRepository blogPostLikeRepository;

        // Constructor to inject the repository dependency
        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
        {
            this.blogPostLikeRepository = blogPostLikeRepository;
        }

        // Endpoint to add a like to a blog post
        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddBlogPostLikeRequest addBlogPostLikeRequest)
        {
            // Call the repository method to add a like for the specified blog post and user
            await blogPostLikeRepository.AddLikeForBlog(addBlogPostLikeRequest.BlogPostId,addBlogPostLikeRequest.UserId);

            // Return success status
            return Ok();
        }

        // Endpoint to get the total likes for a specific blog post
        [Route("{blogPostId:Guid}/totallikes")]
        [HttpGet]
        public async Task<IActionResult> GetTotalLikes([FromRoute] Guid blogPostId)
        {
            // Call the repository method to get the total likes for the specified blog post
            var totalLikes = await blogPostLikeRepository.GetTotalLikesForBlog(blogPostId);

            // Return the total likes as a response
            return Ok(totalLikes);
        }
    }
}
