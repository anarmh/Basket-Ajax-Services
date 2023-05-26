using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;

namespace Molla_template_with_backend.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;
        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.Where(m => !m.SoftDelete).ToListAsync();
        }
    }
}
