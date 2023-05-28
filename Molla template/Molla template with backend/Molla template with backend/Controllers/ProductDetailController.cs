using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;

namespace Molla_template_with_backend.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;
        public ProductDetailController(AppDbContext context)
        {
             _context= context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.Include(m=>m.productImages).Include(m=>m.Category).Where(m => !m.SoftDelete).FirstOrDefaultAsync(m => m.Id == id);

            if(product is null) return NotFound();

            return View(product);
        }
    }
}
