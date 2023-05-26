using Molla_template_with_backend.Models;

namespace Molla_template_with_backend.Services.Interfaces
{
    public interface IBrandService
    {
        public Task<IEnumerable<Brand>> GetBrandsAsync();
    }
}
