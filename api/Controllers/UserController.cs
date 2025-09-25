using api.Models;
using api.Services;

namespace api.Controllers;

using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    

    public UserController(IUserService userService)
    {
        _userService = userService;
        
    }

    [HttpGet]
    public ActionResult<IEnumerable<User>> GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User user)
    {
        var createdUser = _userService.CreateUser(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    
}