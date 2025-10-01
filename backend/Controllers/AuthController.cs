using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;
using backend.DTOs;
using backend.Services.Interfaces;
namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        try
        {
            var usuario = _authService.Register(request);
            return Ok(usuario);
        }
        catch (Exception ex)
        {
            return BadRequest(new { mensaje = ex.Message });
        }
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            var usuario = _authService.Login(request.Email, request.Contrasena);
            return Ok(new { mensaje = "Login Exitoso", usuario });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { mensaje = ex.Message });
        }
    }
}
