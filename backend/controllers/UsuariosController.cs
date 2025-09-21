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
}