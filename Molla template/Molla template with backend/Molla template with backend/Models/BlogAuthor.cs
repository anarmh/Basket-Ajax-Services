namespace Molla_template_with_backend.Models
{
    public class BlogAuthor:BaseEntity
    {
        public string FullName { get; set; }
        public ICollection<Blog> Blogs { get; set; }
    }
}
