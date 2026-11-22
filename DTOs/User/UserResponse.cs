using KryptonApi_EFCore.Models.Enums;

namespace KryptonApi_EFCore.DTOs.User;

public class UserResponse
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public UserType Role { get; set; } = UserType.User;
}