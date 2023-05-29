using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Areas.Admin.ViewModels.Products;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        public ProductController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductVM> listProducts = new();
            List<Product> dbProducts=await _context.Products.Include(m=>m.productImages).Include(m=>m.Category).Where(m=>!m.SoftDelete).Take(6).ToListAsync();
            
            foreach (var dbProduct in dbProducts)
            {
                ProductVM model = new()
                {
                    Id= dbProduct.Id,
                    Title = dbProduct.Title,
                    Description = dbProduct.Description,
                    Price = dbProduct.Price,
                    Category = dbProduct.Category,
                    ProductImages = dbProduct.productImages,
                };
                listProducts.Add(model);
            }
            
            
            return View(listProducts);
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if(id is null) return BadRequest();

            Product product = await _context.Products.Include(m => m.productImages).Include(m => m.Category).FirstOrDefaultAsync(x => x.Id == id);

            if(product == null) return NotFound();

            ProductDetailVM model = new()
            {
                Title = product.Title,
                Description = product.Description,
                Price = product.Price,
                Category = product.Category,
                ProductImages = product.productImages,
            };

            return View(model);
        }
    }
}
