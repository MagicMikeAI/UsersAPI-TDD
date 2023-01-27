using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace UsersWeb.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _usersService;

    public UserController(IUserService userService)
    {
        _usersService = userService;

    }

    [HttpGet(Name = "GetUsers")]

    public async Task<IActionResult> Get()
    {
        var users = await _usersService.GetUsers();

        if (users.Any())
        {
            return Ok(users);
        }
        return NotFound();

    }
}
