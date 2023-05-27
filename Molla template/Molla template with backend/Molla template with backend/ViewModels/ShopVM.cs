using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}
