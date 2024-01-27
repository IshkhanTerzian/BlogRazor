namespace BlogRazor.Web.Models.Domain
{
    public class BlogPostComment
    {
        // Unique identifier for the comment.
        public Guid Id { get; set; }

        // Description or content of the comment.
        public string Description { get; set; }

        // Unique identifier of the associated blog post.
        public Guid BlogPostId { get; set; }

        // Unique identifier of the user who added the comment.
        public Guid UserId { get; set; }

        // Date and time when the comment was added.
        public DateTime DateAdded { get; set; }
    }
}
