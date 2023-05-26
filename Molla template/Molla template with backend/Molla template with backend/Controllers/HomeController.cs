using Microsoft.AspNetCore.Mvc;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;
using Molla_template_with_backend.ViewModels;
using System.Diagnostics;

namespace Molla_template_with_backend.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly ISliderInfoService _sliderInfoService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IBrandService _brandService;

        public HomeController(ISliderService sliderService,
                              ISliderInfoService sliderInfoService,
                              IProductService productService,
                              ICategoryService categoryService,
                              IBrandService brandService)
        {
            _sliderService= sliderService;
            _sliderInfoService= sliderInfoService;
            _productService= productService;
            _categoryService= categoryService;
            _brandService = brandService;
        }
       

        public async Task<IActionResult> Index()
        {
           IEnumerable<Slider> sliders=await _sliderService.GetSliderAsync();
           IEnumerable<SliderInfo> sliderinfos = await _sliderInfoService.GetSliderInfoAsync();
           IEnumerable<Product> products= await _productService.GetProductsAsync();
           IEnumerable<Category> categories=await _categoryService.GetCategoriesAsync();
            IEnumerable<Brand> brands = await _brandService.GetBrandsAsync();
           

            HomeVM model = new()
            {
                Sliders = sliders,
                SliderInfos = sliderinfos,
                Products = products,
                Categories= categories,
                Brands=brands,
            };
            return View(model);
        }

        
    }
}