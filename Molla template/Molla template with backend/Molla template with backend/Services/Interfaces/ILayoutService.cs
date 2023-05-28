using Molla_template_with_backend.ViewModels;

namespace Molla_template_with_backend.Services.Interfaces
{
    public interface ILayoutService
    {
        public LayoutVM GetSettingsAsync();
    }
}
