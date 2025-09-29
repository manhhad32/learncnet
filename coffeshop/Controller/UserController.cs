using Coffeshop.Dto;
using Coffeshop.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Coffeshop.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public UserController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [AllowAnonymous] // Bỏ qua bộ lọc xác thực toàn cục cho API này
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {

            var token = _loginService.login(loginRequest);
            return Ok(new { token });
           
        }


    }
}