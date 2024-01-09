using BlogRazor.Web.Models.Domain;
using BlogRazor.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazor.Web.Pages.Blog
{
    public class DetailsModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        public BlogPost BlogPost { get; set; }

        public DetailsModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
            }

        public async Task<IActionResult> OnGet(string heading)
        {
            BlogPost = await blogPostRepository.GetAsync(heading);
           return Page();
        }
    }
}
