using backend.Data;
namespace backend.Models;

public class LoginRequest
{
    public string Email { get; set; } = string.Empty;
    public string Contrasena { get; set; } = string.Empty;
}