using backend.DTOs;
using backend.Models;

namespace backend.Services.Interfaces;

public interface IAuthService
{
	User Register(RegisterRequest request);
	User Login(string Email, string Password);
}