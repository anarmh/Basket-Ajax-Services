namespace Molla_template_with_backend.Models
{
    public class Blog:BaseEntity
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
        public int BlogAuthorId { get; set; }
        public BlogAuthor BlogAuthor { get; set; }
    }
}
