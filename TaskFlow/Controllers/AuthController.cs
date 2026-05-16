using Microsoft.AspNetCore.Mvc;
using TaskFlow.DTOs;
using TaskFlow.Validators;

namespace TaskFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        var validator = new UserValidator();
        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        }

        return Ok("Пользователь создан");
    }
}
