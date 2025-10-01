using backend.DTOs;
using backend.Models;

namespace backend.Services.Interfaces;

public interface IAuthService
{
	Usuario Register(RegisterRequest request);
	Usuario Login(string Email, string contrasena);
}