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

        public BlogPostLikeController(IBlogPostLikeRepository blogPostLikeRepository)
            {
            this.blogPostLikeRepository = blogPostLikeRepository;
            }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddLike([FromBody] AddBlogPostLikeRequest addBlogPostLikeRequest)
            {
            await blogPostLikeRepository.AddLikeForBlog(addBlogPostLikeRequest.BlogPostId, addBlogPostLikeRequest.UserId);

            return Ok();
            }


        [Route("{blogPostId:Guid}/totallikes")]
        [HttpGet]
        public async Task<IActionResult> GetTotalLikes([FromRoute] Guid blogPostId)
            {
            var totalLikes = await blogPostLikeRepository.GetTotalLikesForBlog(blogPostId);

            return Ok(totalLikes);
            }
        }
    }