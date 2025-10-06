namespace backend.Models;

public class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Contrasena { get; set; } = string.Empty;

    //relacion entre salario y usuarios
    public List<Salario> salarios { get; set; };

}