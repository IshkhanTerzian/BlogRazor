using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using BlogRazor.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazor.Web.Pages.Admin.Blogs
    {
    public class AddModel : PageModel
        {

        private readonly BlogRazorDbContext _blogRazorDbContext;

        [BindProperty]
        public AddBlogPost AddBlogPostRequest { get; set; }


        public AddModel(BlogRazorDbContext blogRazorDbContext)
            {
            this._blogRazorDbContext = blogRazorDbContext;
            }

        public void OnGet()
            {

            }

        public IActionResult OnPost()
            {
            var blogPost = new BlogPost()
                {
                Heading = AddBlogPostRequest.Heading,
                PageTitle = AddBlogPostRequest.PageTitle,
                Content = AddBlogPostRequest.Content,
                ShortDescription = AddBlogPostRequest.ShortDescription,
                FeaturedImageUrl = AddBlogPostRequest.FeaturedImageUrl,
                PublishedDate = AddBlogPostRequest.PublishedDate,
                UrlHandle = AddBlogPostRequest.UrlHandle,
                Author = AddBlogPostRequest.Author,
                Visible = AddBlogPostRequest.Visible
                };

            _blogRazorDbContext.BlogPosts.Add(blogPost);
            _blogRazorDbContext.SaveChanges();

            return RedirectToPage("/Admin/Blogs/List");
            }
        }
    }
