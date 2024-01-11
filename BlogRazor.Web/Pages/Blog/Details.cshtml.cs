using BlogRazor.Web.Models.Domain;using BlogRazor.Web.Models.ViewModels;using BlogRazor.Web.Repositories;using Microsoft.AspNetCore.Identity;using Microsoft.AspNetCore.Mvc;using Microsoft.AspNetCore.Mvc.RazorPages;using System.ComponentModel.DataAnnotations;namespace BlogRazor.Web.Pages.Blog    {    public class DetailsModel : PageModel        {        private readonly IBlogPostRepository blogPostRepository;        private readonly IBlogPostLikeRepository blogPostLikeRepository;        private readonly IBlogPostCommentRepository blogPostCommentRepository;        private readonly SignInManager<IdentityUser> signInManager;        private readonly UserManager<IdentityUser> userManager;        public BlogPost BlogPost { get; set; }        public int TotalLikes { get; set; }        public bool Liked { get; set; }        [BindProperty]        public Guid BlogPostId { get; set; }        [BindProperty]        [Required]        [MinLength(1)]        [MaxLength(100)]        public string CommentDescription { get; set; }        public List<BlogComment> Comments { get; set; }        public DetailsModel(IBlogPostRepository blogPostRepository, IBlogPostLikeRepository blogPostLikeRepository, IBlogPostCommentRepository blogPostCommentRepository,            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)            {            this.blogPostRepository = blogPostRepository;            this.blogPostLikeRepository = blogPostLikeRepository;            this.blogPostCommentRepository = blogPostCommentRepository;            this.signInManager = signInManager;            this.userManager = userManager;            }        public async Task<IActionResult> OnGet(string heading)            {
            await GetBlog(heading);            return Page();            }        public async Task<IActionResult> OnPost(string heading)            {            if (ModelState.IsValid)
                {
                if (signInManager.IsSignedIn(User) && !string.IsNullOrWhiteSpace(CommentDescription))
                    {

                    var userId = userManager.GetUserId(User);

                    var comment = new BlogPostComment
                        {
                        BlogPostId = BlogPostId,
                        Description = CommentDescription,
                        DateAdded = DateTime.Now,
                        UserId = Guid.Parse(userId)
                        };

                    await blogPostCommentRepository.AddAsync(comment);
                    }
                return RedirectToPage("/Blog/Details", new { heading = heading });
                }

            await GetBlog(heading);
            return Page();            }        private async Task GetComments()
            {
            var blogPostComments = await blogPostCommentRepository.GetAllAsync(BlogPost.Id);
            var blogComments = new List<BlogComment>();

            foreach (var blogPostComment in blogPostComments)
                {
                blogComments.Add(new BlogComment
                    {
                    DateAdded = blogPostComment.DateAdded,
                    Description = blogPostComment.Description,
                    Username = (await userManager.FindByIdAsync(blogPostComment.UserId.ToString())).UserName
                    });
                }

            Comments = blogComments;
            }        private async Task GetBlog(string heading)
            {
            BlogPost = await blogPostRepository.GetAsync(heading);            if (BlogPost != null)                {                BlogPostId = BlogPost.Id;                if (signInManager.IsSignedIn(User))                    {                    var likes = await blogPostLikeRepository.GetLikesForBlog(BlogPost.Id);                    var userId = userManager.GetUserId(User);                    Liked = likes.Any(x => x.UserId == Guid.Parse(userId));                    await GetComments();                    }                TotalLikes = await blogPostLikeRepository.GetTotalLikesForBlog(BlogPost.Id);                }
            }        }    }