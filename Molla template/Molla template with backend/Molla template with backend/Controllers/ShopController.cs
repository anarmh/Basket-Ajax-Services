using Microsoft.AspNetCore.Mvc;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;
using Molla_template_with_backend.ViewModels;

namespace Molla_template_with_backend.Controllers
{
    public class ShopController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;

        public ShopController(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
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
    }
}
