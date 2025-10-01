using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Services.Interfaces;

namespace backend.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context; 
    }

    public Usuario Register(RegisterRequest request)
    {
        if (string.IsNullOrEmpty(request.Nombre) ||
            string.IsNullOrEmpty(request.Email) ||
            string.IsNullOrEmpty(request.Contrasena))
            throw new Exception("Debe completar todos los campos requeridos");

        if (_context.Usuarios.Any(u => u.Email == request.Email))
            throw new Exception("El email ya está registrado");

        var usuario = new Usuario
        {
            Nombre = request.Nombre,
            Email = request.Email,
            Contrasena = BCrypt.Net.BCrypt.HashPassword(request.Contrasena)
        };

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }

    public Usuario Login(string email, string contrasena)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);

        if (usuario == null)
            throw new Exception("Email o contraseña incorrectos");

        var passwordCorrecta = BCrypt.Net.BCrypt.Verify(contrasena, usuario.Contrasena);
        if (!passwordCorrecta)
            throw new Exception("Email o contraseña incorrectos");

        return usuario;
    }
}