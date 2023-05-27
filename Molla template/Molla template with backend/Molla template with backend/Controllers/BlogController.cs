using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.ViewModels;

namespace Molla_template_with_backend.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BlogAuthor> blogAuthors=await _context.BlogAuthors.Where(m=>!m.SoftDelete).ToListAsync();
            IEnumerable<Blog> blogs = await _context.Blogs.Where(m => !m.SoftDelete).ToListAsync();

            BlogVM model = new()
            {
                BlogAuthors = blogAuthors,
                Blogs = blogs
            };
            return View(model);
        }
    }
}
