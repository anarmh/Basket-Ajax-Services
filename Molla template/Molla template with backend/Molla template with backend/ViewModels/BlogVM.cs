using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.ViewModels
{
    public class BlogVM
    {
        public IEnumerable<BlogAuthor> BlogAuthors { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
    }
}
