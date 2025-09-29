using Coffeshop.Data;
using Coffeshop.Models;
using Microsoft.EntityFrameworkCore;

namespace Coffeshop.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        /// <summary>
        /// Lấy một sản phẩm theo ID bằng cách sử dụng native SQL query.
        /// </summary>
        /// <param name="id">ID của sản phẩm cần tìm.</param>
        /// <returns>Sản phẩm tìm thấy hoặc null.</returns>
        public async Task<Product?> GetByIdNativeAsync(int id)
        {
            // Thực thi câu query "SELECT * FROM product p WHERE p.id = ?1"
            // bằng cú pháp an toàn của EF Core.
            // Biến {id} sẽ tự động được chuyển thành tham số.
            return await _context.Products
                .FromSqlInterpolated($"SELECT * FROM product WHERE id = {id}")
                .FirstOrDefaultAsync();
        }
    }
}