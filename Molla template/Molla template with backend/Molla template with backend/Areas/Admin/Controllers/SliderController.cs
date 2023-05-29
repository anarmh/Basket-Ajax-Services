using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Areas.Admin.ViewModels.Sliders;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;

namespace Molla_template_with_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        public SliderController( AppDbContext context)
        {
            _context = context;    
        }
        public async Task<IActionResult> Index()
        {
            List<SliderVM> listSlider = new();
            List<Slider> sLiders = await _context.Sliders.Where(m => !m.SoftDelete).ToListAsync();
            foreach (var slider in sLiders)
            {

                SliderVM model = new()
                {
                    Id = slider.Id,
                    Image= slider.Image,
                };
                listSlider.Add(model);
            }
           
            return View(listSlider);
        }


        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Slider dbSlider=await _context.Sliders.FirstOrDefaultAsync(m=>m.Id==id);
            
          
            if(dbSlider == null) return NotFound();

            SliderDetailVM model = new()
            {
                Image = dbSlider.Image,
            };
            return View(model);
        }
    }
}
