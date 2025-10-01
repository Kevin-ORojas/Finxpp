using backend.DTOs;

namespace backend.Services.Interfaces;

public interface IUsuarioService
{
    List<UsuarioResponse> ListarUsuarios();
}