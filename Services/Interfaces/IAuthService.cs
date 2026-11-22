using KryptonApi_EFCore.DTOs.Auth;

namespace KryptonApi_EFCore.Services.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(RegisterRequest request);

    Task<AuthResponse> LoginAsync(LoginRequest request);
}