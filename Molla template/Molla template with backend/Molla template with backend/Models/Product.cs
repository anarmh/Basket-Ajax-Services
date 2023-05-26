namespace Molla_template_with_backend.Models
{
    public class Product:BaseEntity
    {
        public int SaleCount { get; set; }
        public int Rate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<ProductImage> productImages { get; set; }
    }
}
