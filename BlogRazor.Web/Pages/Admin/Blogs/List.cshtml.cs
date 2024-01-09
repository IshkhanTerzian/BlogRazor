using BlogRazor.Web.Data;
using BlogRazor.Web.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BlogRazor.Web.Pages.Admin.Blogs
{
    public class ListModel : PageModel
    {

        private readonly BlogRazorDbContext _blogRazorDbContext;

        public List<BlogPost> BlogPosts { get; set; }

        public ListModel(BlogRazorDbContext blogRazorDbContext)
        {
            this._blogRazorDbContext = blogRazorDbContext;
        }

        public void OnGet()
        {
            BlogPosts = _blogRazorDbContext.BlogPosts.ToList();
        }
    }
}
