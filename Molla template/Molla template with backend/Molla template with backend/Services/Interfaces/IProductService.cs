using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetProductsAsync();
    }
}
