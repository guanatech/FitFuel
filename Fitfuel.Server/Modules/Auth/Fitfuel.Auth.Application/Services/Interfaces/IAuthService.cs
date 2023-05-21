using Fitfuel.Auth.Shared.Dtos;

namespace Fitfuel.Auth.Application.Services.Interfaces;

public interface IAuthService
{
    Task<bool> RegisterUserAsync(RegisterDto dto);
    Task<bool> LoginUserAsync(LoginDto dto);

    string GenerateTokenString(LoginDto dto);
}