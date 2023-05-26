using Microsoft.AspNetCore.Mvc;

namespace Molla_template_with_backend.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
