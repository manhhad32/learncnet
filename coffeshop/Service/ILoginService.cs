using co_lib.Dtos;
namespace Coffeshop.Service
{
    public interface ILoginService
    {
        string login(LoginRequest loginRequest);
    }
}