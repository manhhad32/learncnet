using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Coffeshop.Service
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _configuration;

        public JwtService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(string username)
        {
            string? jwtKey = _configuration["Jwt:Key"];
            string? jwtIssuer = _configuration["Jwt:Issuer"];
            string? jwtAudience = _configuration["Jwt:Audience"];

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Tạo các claims (thông tin đi kèm trong token)
            Claim[] claims =
            [
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                // Bạn có thể thêm các claims khác ở đây, ví dụ như vai trò (role)
                // new Claim(ClaimTypes.Role, "Admin")
            ];

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: jwtIssuer,
                audience: jwtAudience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(120), // Thời gian token hết hạn
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}