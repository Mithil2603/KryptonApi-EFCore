using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using KryptonApi_EFCore.Common;
using KryptonApi_EFCore.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace KryptonApi_EFCore.Services;

public record TokenResult(string Token, DateTime ExpiresAt);

public interface ITokenService
{
    TokenResult CreateToken(UserDataModel user);
}

public class TokenService : ITokenService
{
    private readonly JwtSettings _jwtSettings;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IOptions<JwtSettings> options)
    {
        _jwtSettings = options.Value;

        if (string.IsNullOrEmpty(_jwtSettings.Key))
        {
            throw new Exception("Key is not configured yet!");
        }

        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
    }


    public TokenResult CreateToken(UserDataModel user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.ToString()),
        };

        var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);

        var expiresAt = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),

            Expires = expiresAt,
            Issuer = _jwtSettings.Issuer,
            Audience = _jwtSettings.Audience,
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new TokenResult(tokenHandler.WriteToken(token), expiresAt);
    }
}