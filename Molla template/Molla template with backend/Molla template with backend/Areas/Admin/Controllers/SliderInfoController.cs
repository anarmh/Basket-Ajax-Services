using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Areas.Admin.ViewModels.SliderInfos;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderInfoController : Controller
    {
        private readonly AppDbContext _context;

        public SliderInfoController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SliderInfoVM> list = new();
            List<SliderInfo> dbSliderInfos = await _context.SliderInfos.Where(m=>!m.SoftDelete).ToListAsync();

            foreach (var sliderInfo in dbSliderInfos)
            {
                SliderInfoVM model = new()
                {
                    Id = sliderInfo.Id,
                    Title = sliderInfo.Title,
                    Description = sliderInfo.Description,
                };
                list.Add(model);
            }

            return View(list);
        }
    }
}
