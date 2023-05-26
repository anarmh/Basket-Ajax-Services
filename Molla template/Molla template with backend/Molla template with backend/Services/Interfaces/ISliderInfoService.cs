using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.Services.Interfaces
{
    public interface ISliderInfoService
    {
        public Task<IEnumerable<SliderInfo>> GetSliderInfoAsync();
    }
}
