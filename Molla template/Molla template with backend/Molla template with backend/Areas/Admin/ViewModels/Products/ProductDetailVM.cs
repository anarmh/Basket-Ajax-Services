using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.Areas.Admin.ViewModels.Products
{
    public class ProductDetailVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }
    }
}
