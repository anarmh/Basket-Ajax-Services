using FiorelloFront.Data;
using FiorelloFront.Models;
using FiorelloFront.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.ContentModel;

namespace FiorelloFront.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        public CartController(AppDbContext context, IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }
        public async Task<IActionResult> Index()
        {

            List<BasketDetailVM> basketList = new();
            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                List<BasketVM> basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
                foreach (var item in basketDatas)
                {
                    var dbProduct = await _context.Products.Include(m => m.ProductImages).FirstOrDefaultAsync(m=>m.Id==item.Id);

                    if (dbProduct != null)
                    {
                        BasketDetailVM basketDetail = new()
                        {
                            Id = dbProduct.Id,
                            Image = dbProduct.ProductImages.Where(m => m.IsMain).FirstOrDefault().Image,
                            Name = dbProduct.Name,
                            Count = item.Count,
                            Price = dbProduct.Price,
                            TotalPrice = item.Count * dbProduct.Price,
                        };
                        basketList.Add(basketDetail);

                    }
                 
                }
               
            } 
            return View(basketList);
        }

        [HttpPost]
        public async Task<IActionResult> Addbasket(int? id)
        {
            if (id is null) return BadRequest();
            Product product = await _context.Products.FindAsync(id);

            if(product == null) return NotFound();

            List<BasketVM> basket = GetBasketDatas();
            
            AddProductToBasket(basket,product);

            return Ok(basket.Sum(m=>m.Count));
        }


        private List<BasketVM> GetBasketDatas()
        {
            List<BasketVM> basket;
            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);
            }
            else
            {
                basket = new List<BasketVM>();
            }
            return basket;

        }

        private void AddProductToBasket(List<BasketVM> basket, Product product)
        {
            BasketVM existProduct = basket.FirstOrDefault(m => m.Id == product.Id);

            if (existProduct == null)
            {
                basket.Add(new BasketVM
                {
                    Id = product.Id,
                    Count = 1
                });
            }
            else
            {
                existProduct.Count++;
            }


            _accessor.HttpContext.Response.Cookies.Append("basket", JsonConvert.SerializeObject(basket));

           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteProductFrombasket(int? id)
        {
            List<BasketVM> basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);

            var data=basketDatas.FirstOrDefault(m=>m.Id==id);

            basketDatas.Remove(data);

            _accessor.HttpContext.Response.Cookies.Append("basket",JsonConvert.SerializeObject(basketDatas));

            return RedirectToAction(nameof(Index));
        }
    }
}
