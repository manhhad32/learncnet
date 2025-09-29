using Coffeshop.Models;
using Coffeshop.Repositories;

namespace Coffeshop.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        public ProductService(IProductRepository repository)
        {
            productRepository = repository;
        }
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            //return await productRepository.GetByIdAsync(id);
            return await productRepository.GetByIdNativeAsync(id);
        }
    }
}