using Coffeshop.Data;
using Coffeshop.Models;

namespace Coffeshop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        /*
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        */
        private static readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Laptop", Price = 1500 },
            new Product { Id = 2, Name = "Phone", Price = 800}
        };
        public Task<Product?> GetByIdAsync(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            return Task.FromResult(product);
        }
    }
}