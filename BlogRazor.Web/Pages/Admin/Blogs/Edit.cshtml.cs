using BlogRazor.Web.Data;
using BlogRazor.Web.Enums;
using BlogRazor.Web.Models.Domain;
using BlogRazor.Web.Models.ViewModels;
using BlogRazor.Web.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace BlogRazor.Web.Pages.Admin.Blogs
    {
    public class EditModel : PageModel
        {
        private readonly IBlogPostRepository blogPostRepository;

        [BindProperty]
        public BlogPost BlogPost { get; set; }


        public EditModel(IBlogPostRepository blogPostRepository)
            {
            this.blogPostRepository = blogPostRepository;
            }

        public async Task OnGet(Guid id)
            {
            BlogPost = await blogPostRepository.GetAsync(id);
            }

        public async Task<IActionResult> OnPostEdit()
            {
            try
                {
                await blogPostRepository.UpdateAsync(BlogPost);

                ViewData["Notification"] = new Notification
                    {
                    Message = "Record updated succesfully",
                    Type = Enums.NotificationType.Success
                    };
                }
            catch (Exception ex)
                {
                ViewData["Notification"] = new Notification
                    {
                    Message = "Something went wrong.",
                    Type = Enums.NotificationType.Error
                    };
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
