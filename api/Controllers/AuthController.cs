using api.Models;
using api.Services;

namespace api.Controllers;

using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public ActionResult<LoginResponse> Login([FromBody] LoginRequest request)
    {
        var response = _authService.Login(request);
        if (!response.Success)
        {
            return Unauthorized(response);
        }
        return Ok(response);
    }
}