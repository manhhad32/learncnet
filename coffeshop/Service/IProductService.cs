using Coffeshop.Models;

namespace Coffeshop.Service
{
    public interface IProductService
    {
        Task<Product?> GetProductByIdAsync(int id);
    }
    
}