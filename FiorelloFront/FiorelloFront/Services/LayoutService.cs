using FiorelloFront.Data;
using FiorelloFront.Services.Interfaces;
using System.Collections.Generic;

namespace FiorelloFront.Services
{
    public class LayoutService : ILayoutService
    {
        private readonly AppDbContext _context;

        public LayoutService(AppDbContext context)
        {
            _context = context;
        }

        public Dictionary<string, string> GetSettingDatas()
        {
            Dictionary<string,string> datas=_context.Settings.AsEnumerable().ToDictionary(m=>m.Key,m=>m.Value);

            return datas;
        }
    }
}
