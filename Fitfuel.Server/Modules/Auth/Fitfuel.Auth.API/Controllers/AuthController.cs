using Fitfuel.Auth.Application.Services.Interfaces;
using Fitfuel.Auth.Shared.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Fitfuel.Auth.API.Controllers;

[ApiController]
[Route("auth")]
public class AuthController : Controller
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto dto)
    {
        if (!await _authService.LoginUserAsync(dto)) 
            return BadRequest("Something went wrong");
        
        var tokenString = _authService.GenerateTokenString(dto);
        return Ok(tokenString);
    }
    
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterDto dto)
    {
        return await _authService.RegisterUserAsync(dto)
            ? Ok("Successful")
            : BadRequest("Something went wrong");
    }
}