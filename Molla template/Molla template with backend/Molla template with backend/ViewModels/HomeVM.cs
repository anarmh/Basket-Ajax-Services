using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<SliderInfo> SliderInfos { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
    }
}
