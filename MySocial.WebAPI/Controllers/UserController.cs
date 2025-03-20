using Microsoft.AspNetCore.Mvc;
using MySocial.Application.Services;

namespace MySocial.WebAPI.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] string name)
    {
        await _userService.AddUser(name);
        return Ok();
    }
}
