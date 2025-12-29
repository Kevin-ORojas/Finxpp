using backend.Data;
using backend.DTOs;
using backend.Services.Interfaces;

namespace backend.Services;


public class UsersService : IUsersService
{
    private readonly AppDbContext _context;

    public UsersService(AppDbContext context)
    {
        _context = context;
    }

    public List<UserResponse> ListUsers()
    {
        //obtenemos los usuarios de la DB
        var user = _context.Users.ToList();

        // mapeamos los modelos de DTOs

        return user.Select(u => new UserResponse(
            u.Id,
            u.Name,
            u.Email
            )).ToList();
    }

}

