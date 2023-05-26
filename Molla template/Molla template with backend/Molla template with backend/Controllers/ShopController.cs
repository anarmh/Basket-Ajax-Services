using Microsoft.AspNetCore.Mvc;

namespace Molla_template_with_backend.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
