using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;
using Molla_template_with_backend.ViewModels;

namespace Molla_template_with_backend.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly AppDbContext _context;

        public ShopController(ICategoryService categoryService, IProductService productService,AppDbContext context)
        {
            _categoryService = categoryService;
            _productService = productService;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Category> categories=await _categoryService.GetCategoriesAsync();
            IEnumerable<Product> products = await _productService.GetProductsAsync();

            ShopVM model = new()
            {
                Categories = categories,
                Products = products
            };
            return View(model);
        }

        public async Task<IActionResult> GetByCategoryName(int? id)
        {
            if(id is null) return BadRequest();
            List<Product> products=await _context.Products.Include(m=>m.productImages).Where(m=>m.Id==id).ToListAsync();
            if(products is null)return NotFound();
            return View(products);
        }
    }
}
