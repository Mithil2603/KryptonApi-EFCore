using FluentValidation;
using KryptonApi_EFCore.DTOs.Auth;

namespace KryptonApi_EFCore.Validators.Auth;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(u => u.Email).NotEmpty().WithMessage("Email is required!").EmailAddress().WithMessage("Enter a valid email address!").MaximumLength(150);

        RuleFor(u => u.PasswordHash).NotEmpty().WithMessage("Password cannot be empty!").MinimumLength(8).WithMessage("Password must be atleast 8 characters long!");
    }
}