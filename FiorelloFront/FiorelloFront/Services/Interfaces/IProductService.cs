using FiorelloFront.Models;

namespace FiorelloFront.Services.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllAsync();
        public Task<Product> GetByIdAsync(int? id);
        public Task<Product> GetByIdImagesAsync(int? id);
    }
}
