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

    private bool isValidEmail(string emailAddress)
    {
        try
        {
            var mail = new System.Net.Mail.MailAddress(emailAddress);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    [HttpPost("register")]
    public ActionResult<Usuario> PostUsuarios(Usuario usuario)
    {


        if (string.IsNullOrEmpty(usuario.Nombre) ||
        string.IsNullOrEmpty(usuario.Email) ||
        string.IsNullOrEmpty(usuario.Contrasena))
            return BadRequest("Debe completar todos los campos requeridos");

        // pregunta si ya hay usuarios en lista y si hay se suma 1 al id maximo para asiganar un nuevo id

        //  verifica que el email tenga un formato correcto
        if (!isValidEmail(usuario.Email))
            return BadRequest("Formato de correo invalido");

        // verifica emails duplicados
        if (usuarios.Any(u => u.Email == usuario.Email))
            return BadRequest("Email duplicado: 400");

        // asigna un ID automaticamente
        usuario.Id = usuarios.Any() ? usuarios.Max(u => u.Id) + 1 : 1;

        // agrega al usuario
        usuarios.Add(usuario);

        return Ok(usuario);
    }



    [HttpPost("login")]

    public ActionResult PostLogin([FromBody] LoginRequest login)
    {

        if (string.IsNullOrEmpty(login.Email) ||
            string.IsNullOrEmpty(login.Contrasena))
            return BadRequest("Debe completar todos los campos requeridos");


        // Busca al usuario
        var usuarioEncontrado = usuarios.FirstOrDefault(u => u.Email == login.Email && u.Contrasena == login.Contrasena);

        // si el usuario no tiene nada no se autentica
        if (usuarioEncontrado == null)
            return Unauthorized("Email, o contraseña incorrectos");


        return Ok(new { mensaje = "Usuario autenticado extisoamente", usuario = usuarioEncontrado });

    }

}