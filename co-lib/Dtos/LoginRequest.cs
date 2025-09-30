using System.ComponentModel.DataAnnotations;

namespace co_lib.Dtos
{
    public class LoginRequest
    {
        [Required]
        public required string Username { get; set; }

        [Required]
        public required string Password { get; set; }
    }
    
}