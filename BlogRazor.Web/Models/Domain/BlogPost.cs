namespace BlogRazor.Web.Models.Domain
{
    public class BlogPost
    {
        // Unique identifier for the blog post.
        public Guid Id { get; set; }

        // Heading of the blog post.
        public string Heading { get; set; }

        // Page title of the blog post.
        public string PageTitle { get; set; }

        // Content of the blog post.
        public string Content { get; set; }

        // Short description of the blog post.
        public string ShortDescription { get; set; }

        // Author of the blog post.
        public string Author { get; set; }

        // Indicates whether the blog post is visible.
        public bool Visible { get; set; }

        // Published date of the blog post.
        public DateTime PublishedDate { get; set; }

        // Collection of likes associated with the blog post.
        public ICollection<BlogPostLike> Likes { get; set; }

        // Collection of comments associated with the blog post.
        public ICollection<BlogPostComment> Comments { get; set; }
    }
}
