namespace api.Services{
using api.Models;
    public interface IAuthService
    {
        LoginResponse Login(LoginRequest request);
    }
}