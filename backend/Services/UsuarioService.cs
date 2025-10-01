using backend.Data;
using backend.DTOs;
using backend.Services.Interfaces;

namespace backend.Services;

public class UsuarioService : IUsuarioService
{
    private readonly AppDbContext _context;

        public UsuarioService(AppDbContext context)
        {
            _context = context;
        }

    public List<UsuarioResponse> ListarUsuarios()
    {

        //obtenemos los usuarios de la DB
        var usuarios = _context.Usuarios.ToList();

            // mapeamos los modelos de DTOs

            return usuarios.Select(u => new UsuarioResponse(
                u.Id,
                u.Nombre,
                u.Email
                )).ToList();
    }

}


