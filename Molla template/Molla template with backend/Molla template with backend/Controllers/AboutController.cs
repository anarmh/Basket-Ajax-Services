using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;
using Molla_template_with_backend.ViewModels;

namespace Molla_template_with_backend.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IBrandService _brandService;

        public AboutController(AppDbContext context, IBrandService brandService)
        {
            _context = context;
            _brandService = brandService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<TeamMember> teamMembers=await _context.TeamMembers.Where(m=>!m.SoftDelete).ToListAsync();
            IEnumerable<Brand> brands=await _brandService.GetBrandsAsync();

            AboutVM model = new()
            {
                TeamMembers = teamMembers,
                Brands = brands
            };

            return View(model);
        }
    }
}
