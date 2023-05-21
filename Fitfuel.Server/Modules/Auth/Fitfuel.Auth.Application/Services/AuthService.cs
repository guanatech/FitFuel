using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Fitfuel.Auth.Application.Services.Interfaces;
using Fitfuel.Auth.Shared.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Fitfuel.Auth.Application.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<bool> RegisterUserAsync(RegisterDto dto)
    {
        var user = new IdentityUser
        {
            UserName = dto.Username,
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        return result.Succeeded;
    }

    public async Task<bool> LoginUserAsync(LoginDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.Username);
        
        if (user is null) 
            return false;

        return await _userManager.CheckPasswordAsync(user, dto.Password);
    }
    
    public string GenerateTokenString(LoginDto dto)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name,dto.Username),
            new(ClaimTypes.Role,"Admin"),
        };

        var securityKey = new SymmetricSecurityKey("superSecretKey000"u8.ToArray());

        var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            issuer: "FitIssuer",
            audience: "FitAudience",
            signingCredentials: signingCred);

        var tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
        return tokenString;
    }
}