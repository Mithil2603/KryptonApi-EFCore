using KryptonApi_EFCore.Models.Enums;

namespace KryptonApi_EFCore.Models;

public class UserDataModel
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }

    public string? LastName { get; set; }

    public required string Email { get; set; }

    public string PasswordHash { get; set; } = null!;

    public UserType Role { get; set; } = UserType.User;

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }
}