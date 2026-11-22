using System.Net;
using KryptonApi_EFCore.Common.Exceptions;
using KryptonApi_EFCore.Data;
using KryptonApi_EFCore.DTOs.Auth;
using KryptonApi_EFCore.DTOs.User;
using KryptonApi_EFCore.Models;
using KryptonApi_EFCore.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KryptonApi_EFCore.Services;

public class AuthService : IAuthService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IPasswordHasher<UserDataModel> _passwordHasher;
    private readonly ITokenService _tokenService;

    public AuthService(ApplicationDbContext dbContext, IPasswordHasher<UserDataModel> passwordHasher, ITokenService tokenService)
    {
        _dbContext = dbContext;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
    {
        var normalizedEmail = request.Email.ToLower().Trim();

        bool emailExists = await _dbContext.Users.AnyAsync(u => u.Email.ToLower() == normalizedEmail);

        if (emailExists)
        {
            throw new AppException("Email is already registered.", HttpStatusCode.Conflict);
        }

        var user = new UserDataModel
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = normalizedEmail,
            CreatedAt = DateTime.UtcNow
        };

        user.PasswordHash = _passwordHasher.HashPassword(user, request.PasswordHash);

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        var TokenResult = _tokenService.CreateToken(user);

        return new AuthResponse
        {
            Success = true,
            Token = TokenResult.Token,
            ExpiresAt = TokenResult.ExpiresAt,
            User = new UserResponse { Id = user.Id, Email = user.Email, FirstName = user.FirstName, Role = user.Role }
        };
    }

    public async Task<AuthResponse> LoginAsync(LoginRequest request)
    {
        var normalizedEmail = request.Email.ToLower().Trim();

        UserDataModel? user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == normalizedEmail);

        if (user is null)
        {
            throw new AppException("Invalid email or password!", HttpStatusCode.Unauthorized);
        }

        var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.Password);

        if (result == PasswordVerificationResult.Failed)
        {
            throw new AppException("Invalid email or password!", HttpStatusCode.Unauthorized);
        }

        var tokenResult = _tokenService.CreateToken(user);

        return new AuthResponse
        {
            Success = true,
            Token = tokenResult.Token,
            ExpiresAt = tokenResult.ExpiresAt,
            User = new UserResponse { Id = user.Id, Email = user.Email, FirstName = user.FirstName, Role = user.Role }
        };
    }
}