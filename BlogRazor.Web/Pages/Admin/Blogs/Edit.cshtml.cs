using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazor.Web.Pages.Admin.Blogs
    {
    public class EditModel : PageModel
        {
        private readonly BlogRazorDbContext _blogRazorDbContext;

        [BindProperty]
        public BlogPost BlogPost { get; set; }

        public EditModel(BlogRazorDbContext blogRazorDbContext)
            {
            this._blogRazorDbContext = blogRazorDbContext;
            }

        public void OnGet(Guid id)
            {
            BlogPost = _blogRazorDbContext.BlogPosts.Find(id);
            }

        public IActionResult OnPostEdit()
            {
            var existingBlogPost = _blogRazorDbContext.BlogPosts.Find(BlogPost.Id);

            if (existingBlogPost != null)
                {
                existingBlogPost.Heading = BlogPost.Heading;
                existingBlogPost.PageTitle = BlogPost.PageTitle;
                existingBlogPost.Content = BlogPost.Content;
                existingBlogPost.ShortDescription = BlogPost.ShortDescription;
                existingBlogPost.FeaturedImageUrl = BlogPost.FeaturedImageUrl;
                existingBlogPost.UrlHandle = BlogPost.UrlHandle;
                existingBlogPost.PublishedDate = BlogPost.PublishedDate;
                existingBlogPost.Author = BlogPost.Author;
                existingBlogPost.Visible = BlogPost.Visible;
                }

            _blogRazorDbContext.SaveChanges();
            return RedirectToPage("/Admin/Blogs/List");
            }

        public IActionResult OnPostDelete()
            {

            var existingBlog = _blogRazorDbContext.BlogPosts.Find(BlogPost.Id);

            if (existingBlog != null)
                {
                _blogRazorDbContext.BlogPosts.Remove(existingBlog);
                _blogRazorDbContext.SaveChanges();
                return RedirectToPage("/Admin/Blogs/List");

                }

            return Page();
            }
        }
    }
