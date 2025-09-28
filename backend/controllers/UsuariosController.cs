using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService _usuarioService;

    public UsuariosController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpPost("register")]
    public IActionResult CrearUsuario([FromBody] Usuario nuevoUsuario)
    {
        try
        {
            var usuarioCreado = _usuarioService.CrearUsuario(nuevoUsuario);
            return Ok(usuarioCreado);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }


    }
    [HttpPost("login")]
    public ActionResult PostLogin([FromBody] LoginRequest login)
    {
        try
        {
            var usuario = _usuarioService.LoginUsuario(login.Email, login.Contrasena);
            // si el usuario tiene todo correcto se autentica exitosamente
            return Ok(new { mensaje = "Usuario autenticado extisoamente", usuario });
        }
        catch (Exception ex)
        {

            return Unauthorized(ex.Message);
        }
    }
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        var usuarios = _usuarioService.ListarUsuarios();
        return Ok(usuarios);
    }

}