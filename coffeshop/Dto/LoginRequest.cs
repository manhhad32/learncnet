using System.ComponentModel.DataAnnotations;

namespace Coffeshop.Dto
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
    
}