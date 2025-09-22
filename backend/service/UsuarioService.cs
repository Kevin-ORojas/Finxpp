using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

public class UsuarioService
{
    private static List<Usuario> usuarios = new List<Usuario>();

    public Usuario CrearUsuario(Usuario usuario)
    {
        if (string.IsNullOrEmpty(usuario.Nombre) ||
       string.IsNullOrEmpty(usuario.Email) ||
       string.IsNullOrEmpty(usuario.Contrasena))
            throw new Exception("Debe completar todos los campos requeridos");

        // pregunta si ya hay usuarios en lista y si hay se suma 1 al id maximo para asiganar un nuevo id

        //  verifica que el email tenga un formato correcto
        if (!isValidEmail(usuario.Email))
            throw new Exception("Formato de correo invalido");

        // verifica emails duplicados
        if (usuarios.Any(u => u.Email == usuario.Email))
            throw new Exception("Email duplicado: 400");

        // asigna un ID automaticamente
        usuario.Id = usuarios.Any() ? usuarios.Max(u => u.Id) + 1 : 1;

        // agrega al usuario
        usuarios.Add(usuario);

        return usuario;
    }


    public Usuario LoginUsuario(string Email, string Contrasena)
    {
        if (string.IsNullOrEmpty(Email) ||
           string.IsNullOrEmpty(Contrasena))
            throw new Exception("Debe completar todos los campos requeridos");


        // Busca al usuario
        var usuarioEncontrado = usuarios.FirstOrDefault(u => u.Email == Email && u.Contrasena == Contrasena);

        // si el usuario no tiene nada no se autentica
        if (usuarioEncontrado == null)
            throw new Exception("Email, o contraseña incorrectos");

        return usuarioEncontrado;

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

    public List<object> ListarUsuarios()
    {
        return usuarios.Select(u => new { u.Id, u.Nombre, u.Email }).ToList<object>();
    }

}

