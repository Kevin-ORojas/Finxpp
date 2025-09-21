using Microsoft.AspNetCore.Mvc;
using backend.Models;


namespace backend.Controller;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{

    private static List<Usuario> usuarios = new List<Usuario>();
    [HttpGet]

    public ActionResult<IEnumerable<Usuario>> GetUsuarios()
    {
        return Ok(usuarios);
    }

    [HttpPost]
    public ActionResult<Usuario> PostUsuarios(Usuario usuario)
    {

        if (string.IsNullOrEmpty(usuario.Nombre) ||
        string.IsNullOrEmpty(usuario.Email) ||
         string.IsNullOrEmpty(usuario.Contraseña))
        {
            return BadRequest("Debe completar todos los campos requeridos")
 ;
        }

        usuario.Id = usuarios.Any() ? usuarios.Max(u => u.Id) + 1 : 1;

        if (usuarios.Any(u => u.Email == usuario.Email))
        {
            return BadRequest("Email duplicado: 400");
        }
        else
        {
            usuarios.Add(usuario);

            return Ok(usuario);
        }
    }

}