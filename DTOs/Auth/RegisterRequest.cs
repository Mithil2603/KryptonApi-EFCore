namespace KryptonApi_EFCore.DTOs.Auth;

public class RegisterRequest
{
    public required string FirstName { get; set; }

    public string? LastName { get; set; }

    public required string Email { get; set; }

    public required string PasswordHash { get; set; }
}