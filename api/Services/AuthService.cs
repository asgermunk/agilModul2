namespace api.Services;
using api.Models;

public class AuthService : IAuthService
{
    private readonly IUserService _userService;

    public AuthService(IUserService userService)
    {
        _userService = userService;
    }

    public LoginResponse Login(LoginRequest request)
    {
        var users = _userService.GetAllUsers();
        var user = users.FirstOrDefault(u => u.Email == request.Email && u.Password == request.Password);

        if (user == null)
        {
            return new LoginResponse
            {
                Success = false,
                Message = "Invalid email or password."
            };
        }

        return new LoginResponse
        {
            Success = true,
            Message = "Login successful.",
            User = user
        };
    }
}