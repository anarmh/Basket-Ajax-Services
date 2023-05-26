using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;

namespace Molla_template_with_backend.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;    
        }
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.Include(m=>m.productImages).Where(m=>!m.SoftDelete).ToListAsync();
        }
    }
}
