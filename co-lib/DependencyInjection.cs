using co_lib.Configurations; // Namespace chứa AddJwtAuthentication của bạn
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace co_lib
{
    public static class DependencyInjection
    {
        // Phương thức phải là static và tham số đầu tiên có "this"
        public static IServiceCollection AddedServices(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            // 1. Thêm xác thực JWT (từ file cấu hình cũ của bạn)
            services.AddJwtAuthentication(configuration);

            // 2. Thêm Controllers và áp dụng Authorize Filter toàn cục
            // Lưu ý: Bạn chỉ cần gọi AddControllers một lần.
            services.AddControllers(options =>
            {
                // Áp dụng bảo vệ cho tất cả các API endpoint
                options.Filters.Add(new AuthorizeFilter());
            });

            // 3. Thêm Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddAuthentication();
            services.AddAuthorization();


            // Đăng ký dịch vụ để *tạo ra* tài liệu Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(); 
            
            // Return services để có thể gọi nối tiếp (chaining) nếu cần
            return services;
        }
    }
}