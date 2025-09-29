using Coffeshop.Dto;

namespace Coffeshop.Service
{
    public interface ILoginService
    {
        string login(LoginRequest loginRequest);
    }
}