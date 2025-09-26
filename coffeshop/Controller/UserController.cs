using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Coffeshop.Dto;
using Coffeshop.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Coffeshop.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtService _jwtService;

        public UserController(IConfiguration configuration, IJwtService jwtService)
        {
            _configuration = configuration;
            _jwtService = jwtService;
        }

        [AllowAnonymous] // Bỏ qua bộ lọc xác thực toàn cục cho API này
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
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
                return Ok(new { token });
            }

            // Nếu sai, trả về lỗi
            return Unauthorized("Invalid username or password");
        }


    }
}