using co_lib.Dtos;

namespace Coffeshop.Service
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;

        public LoginService(IConfiguration configuration, IJwtService jwtService)
        {
            _configuration = configuration;
            _jwtService = jwtService;
        }

        public string login(LoginRequest loginRequest)
        {
            // Lấy thông tin người dùng "cứng" từ appsettings.json
            var hardcodedUser = _configuration.GetSection("HardcodedUser");
            var username = hardcodedUser["Username"];
            var password = hardcodedUser["Password"];

            // Kiểm tra thông tin đăng nhập
            if (loginRequest.Username == username && loginRequest.Password == password)
            {
                // Nếu đúng, tạo token
                var token = _jwtService.GenerateJwtToken(loginRequest.Username);
                return token;
            }

            // Nếu sai, trả về lỗi
            throw new UnauthorizedAccessException("Invalid username or password");
        }
    }
}