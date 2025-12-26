using backend.DTOs;

namespace backend.Services.Interfaces;

public interface IUsersService
{
    List<UserResponse> ListUsers();
}