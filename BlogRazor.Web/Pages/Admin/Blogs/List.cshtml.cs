using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using BlogRazor.Web.Models.ViewModels;
using BlogRazor.Web.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace BlogRazor.Web.Pages.Admin.Blogs
{

    [Authorize(Roles = "Admin")]
    public class ListModel : PageModel
    {

        private readonly IBlogPostRepository blogPostRepository;

        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(IBlogPostRepository blogPostRepository)
        {
            this.blogPostRepository = blogPostRepository;
        }

        public async Task OnGet()
        {
            var notificationJson = (string)TempData["Notification"];

            if (notificationJson != null)
            {
                ViewData["Notification"] = JsonSerializer.Deserialize<Notification>(notificationJson);
            }

            BlogPosts = (await blogPostRepository.GetAllAsync())?.ToList();
        }
    }
}
