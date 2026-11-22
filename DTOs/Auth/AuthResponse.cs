using KryptonApi_EFCore.DTOs.User;

namespace KryptonApi_EFCore.DTOs.Auth;

public class AuthResponse
{
    public bool Success { get; set; }

    public string Token { get; set; } = null!;

    public DateTime ExpiresAt { get; set; }

    public UserResponse? User { get; set; }
}