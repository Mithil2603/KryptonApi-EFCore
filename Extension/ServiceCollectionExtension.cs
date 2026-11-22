using FluentValidation;
using KryptonApi_EFCore.Common;
using KryptonApi_EFCore.Data;
using KryptonApi_EFCore.Middleware;
using KryptonApi_EFCore.Services;
using KryptonApi_EFCore.Services.Interfaces;
using KryptonApi_EFCore.Validators.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace KryptonApi_EFCore.Extension;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddControllers()
            .AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
        {

        });
        services.Configure<JwtSettings>(configuration.GetSection("Jwt"));
        services.AddScoped(typeof(IPasswordHasher<>), typeof(PasswordHasher<>));
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IAuthService, AuthService>();

        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();

        services.AddExceptionHandler<GlobalExceptionHandler>();
        services.AddProblemDetails();

        return services;
    }
}