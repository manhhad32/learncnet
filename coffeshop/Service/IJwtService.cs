namespace Coffeshop.Service
{
    public interface IJwtService
    {
        string GenerateJwtToken(string username);
    }
}