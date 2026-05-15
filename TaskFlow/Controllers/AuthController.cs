using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.DTOs;
using TaskFlow.Validators;

namespace TaskFlow.Controllers;

[RequireHttps]
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
       var validator = new Validator.Validate(request);
       var result = vvalidator.Validate(request);

        if (!result.IsValid)
        {
            return BadRequest(result.Errors);
        } else return OK("");
    }
} 
