using KryptonApi_EFCore.DTOs.Auth;
using KryptonApi_EFCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KryptonApi_EFCore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _service;

    public AuthController(IAuthService service)
    {
        _service = service;
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync(RegisterRequest request)
    {
        var response = await _service.RegisterAsync(request);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var response = await _service.LoginAsync(request);
        return Ok(response);
    }
}