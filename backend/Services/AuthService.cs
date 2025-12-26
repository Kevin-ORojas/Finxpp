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

    public User Register(RegisterRequest request)
    {
        if (string.IsNullOrEmpty(request.Name) ||
            string.IsNullOrEmpty(request.Email) ||
            string.IsNullOrEmpty(request.Password))
            throw new Exception("Debe completar todos los campos requeridos");

        if (_context.Users.Any(u => u.Email == request.Email))
            throw new Exception("El email ya está registrado");

        var user = new User
        {
            Name = request.Name,
            Email = request.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password)
        };

        _context.Users.Add(user);
        _context.SaveChanges();
        return user;
    }

    public User Login(string email, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Email == email);

        if (user == null)
            throw new Exception("Email o contraseña incorrectos");

        var passwordCorrecta = BCrypt.Net.BCrypt.Verify(password, user.Password);
        if (!passwordCorrecta)
            throw new Exception("Email o contraseña incorrectos");

        return user;
    }
}