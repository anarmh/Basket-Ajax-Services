using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;

namespace Molla_template_with_backend.Services
{
    public class BrandService : IBrandService
    {
        private readonly AppDbContext _context;

        public BrandService(AppDbContext context )
        {
            _context = context;
        }
        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _context.Brands.Where(m=>!m.SoftDelete).ToListAsync();
        }
    }
}
