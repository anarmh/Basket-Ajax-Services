using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;

namespace Molla_template_with_backend.Services
{
    public class SliderService : ISliderService
    {
        private readonly AppDbContext _context;
        public SliderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Slider>> GetSliderAsync()
        {
            return await _context.Sliders.Where(m => !m.SoftDelete).ToListAsync();
        }
    }
}
