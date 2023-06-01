using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Areas.Admin.ViewModels.TeamMembers;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamMemberController : Controller
    {
        private readonly AppDbContext _context;
        public TeamMemberController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<TeamMemberVM> list = new();
            List<TeamMember> teams = await _context.TeamMembers.Where(m => !m.SoftDelete).ToListAsync();

            foreach (var team in teams)
            {
                TeamMemberVM model = new()
                {
                    Id= team.Id,
                    FullName = team.FullName,
                    Description = team.Description,
                    Image = team.Image,
                    Position = team.Position,
                };
                list.Add(model);
            }
            return View(list);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if(id is null) return BadRequest();

            TeamMember member= await _context.TeamMembers.FirstOrDefaultAsync(m=>m.Id == id);

            if(member == null) return NotFound();

            TeamMemberDetailVM model = new()
            {
                FullName = member.FullName,
                Description = member.Description,
                Image = member.Image,
                Position = member.Position,
            };

            return View(model);
        }
    }
}
