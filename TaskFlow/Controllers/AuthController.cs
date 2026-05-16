using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using TaskFlow.Data;
using TaskFlow.DTOs;
using TaskFlow.Models;
using TaskFlow.Validators;

namespace TaskFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly TaskDb _db;

    public AuthController(TaskDb db)
    {
        _db = db;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        
        var validator = new UserValidator();
        var validationResult = validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
        }

        
        bool userExists = await _db.Users.AnyAsync(u => u.Email == request.Email);
        if (userExists)
        {
            return BadRequest(new { message = "Пользователь с таким Email уже зарегистрирован" });
        }
        
        
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        
        
        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            Email = request.Email,
            HashPassword = passwordHash 
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return Ok(new { message = "Пользователь успешно создан" });
    }
}