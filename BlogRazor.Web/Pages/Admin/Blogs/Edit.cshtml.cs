using BlogRazor.Web.Data;
using BlogRazor.Web.Enums;
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
    public class EditModel : PageModel
    {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public EditBlogPostRequest BlogPost { get; set; }


        public EditModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet(Guid id)
        {
            var blogPostModel = await blogPostRepository.GetAsync(id);

            if (blogPostModel != null)
            {
                BlogPost = new EditBlogPostRequest
                {
                    Id = blogPostModel.Id,
                    Heading = blogPostModel.Heading,
                    PageTitle = blogPostModel.PageTitle,
                    Content = blogPostModel.Content,
                    ShortDescription = blogPostModel.ShortDescription,
                    Author = blogPostModel.Author,
                    Visible = blogPostModel.Visible,
                    PublishedDate = blogPostModel.PublishedDate
                };
            }
        }

        public async Task<IActionResult> OnPostEdit()
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var blogPostModel = new BlogPost
                    {
                        Id = BlogPost.Id,
                        Heading = BlogPost.Heading,
                        PageTitle = BlogPost.PageTitle,
                        Content = BlogPost.Content,
                        ShortDescription = BlogPost.ShortDescription,
                        Author = BlogPost.Author,
                        Visible = BlogPost.Visible,
                        PublishedDate = BlogPost.PublishedDate
                    };

                    await blogPostRepository.UpdateAsync(blogPostModel);

                    var notification = new Notification
                    {
                        Message = "Blog post updated succesfully",
                        Type = Enums.NotificationType.Success
                    };

                    TempData["Notification"] = JsonSerializer.Serialize(notification);
                    return RedirectToPage("/Admin/Blogs/List");
                } catch (Exception ex)
                {
                    ViewData["Notification"] = new Notification
                    {
                        Message = "Something went wrong.",
                        Type = Enums.NotificationType.Error
                    };
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDelete()
        {

            var deleted = await blogPostRepository.DeleteAsync(BlogPost.Id);

            if (deleted)
            {
                var notification = new Notification
                {
                    Message = "Blog post deleted succesfully",
                    Type = Enums.NotificationType.Success
                };

                TempData["Notification"] = JsonSerializer.Serialize(notification);
                return RedirectToPage("/Admin/Blogs/List");
            }
            return Page();
        }
    }
}
