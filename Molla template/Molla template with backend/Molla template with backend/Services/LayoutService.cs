using Molla_template_with_backend.Data;
using Molla_template_with_backend.Models;
using Molla_template_with_backend.Services.Interfaces;
using Molla_template_with_backend.ViewModels;

namespace Molla_template_with_backend.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;
        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public LayoutVM GetSettingsAsync()
        {
            Dictionary<string, string> settings =  _context.Settings.AsEnumerable().ToDictionary(m => m.Key, m => m.Value);

            LayoutVM layout = new()
            {
                Settings = settings,
            };
        
            return layout;
        }
    }
}
