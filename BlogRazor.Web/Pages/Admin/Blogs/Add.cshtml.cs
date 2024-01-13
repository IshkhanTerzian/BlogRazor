using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using BlogRazor.Web.Models.ViewModels;
using BlogRazor.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BlogRazor.Web.Pages.Admin.Blogs
{
    [Authorize(Roles = "Admin")]
    public class AddModel : PageModel
    {

        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }

        public AddModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {

            if (ModelState.IsValid)
            {
                var blogPost = new BlogPost()
                {
                    Heading = AddBlogPostRequest.Heading,
                    PageTitle = AddBlogPostRequest.PageTitle,
                    Content = AddBlogPostRequest.Content,
                    ShortDescription = AddBlogPostRequest.ShortDescription,
                    PublishedDate = AddBlogPostRequest.PublishedDate,
                    Author = AddBlogPostRequest.Author,
                    Visible = AddBlogPostRequest.Visible
                };

                await blogPostRepository.AddAsync(blogPost);

                var notification = new Notification
                {
                    Message = "Blog post created succesfully",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);

                return RedirectToPage("/Admin/Blogs/List");
            }
            return Page();
        }
    }
}
