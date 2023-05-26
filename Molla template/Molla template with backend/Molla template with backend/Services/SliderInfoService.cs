using Microsoft.EntityFrameworkCore;
using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;

namespace Molla_template_with_backend.Services
{
    public class SliderInfoService : ISliderInfoService
    {
        private readonly AppDbContext _context;
        public SliderInfoService(AppDbContext context)
        {
            _context = context;
        }

      

        public async Task<IEnumerable<SliderInfo>> GetSliderInfoAsync()
        {
            return await _context.SliderInfos.Where(m => !m.SoftDelete).ToListAsync();
        } 
    }
}
