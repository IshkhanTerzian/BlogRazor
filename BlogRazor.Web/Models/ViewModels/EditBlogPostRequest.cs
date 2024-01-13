using System.ComponentModel.DataAnnotations;

namespace BlogRazor.Web.Models.ViewModels
{
    public class EditBlogPostRequest
    {

        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Heading { get; set; }

        [Required]
        public string PageTitle { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public bool Visible { get; set; }

        [Required]
        public DateTime PublishedDate { get; set; }
    }
}
