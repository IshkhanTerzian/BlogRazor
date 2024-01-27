namespace BlogRazor.Web.Models.Domain
{
    public class BlogPostLike
    {
        // Unique identifier for the like.
        public Guid Id { get; set; }

        // Unique identifier of the associated blog post.
        public Guid BlogPostId { get; set; }

        // Unique identifier of the user who added the like.
        public Guid UserId { get; set; }
    }
}
