using Coffeshop.Models;

namespace Coffeshop.Repositories
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
    }
}