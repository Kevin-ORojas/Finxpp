using backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using backend.Data;

namespace backend.Services;

public class UsuarioService
{
    private readonly AppDbContext _context;

    public UsuarioService(AppDbContext context)
    {
        _context = context;
    }

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
        if (_context.Usuarios.Any(u => u.Email == usuario.Email))
            throw new Exception("Email duplicado: 400");

        // asigna un ID automaticamente
        // usuario.Id = _context.Usuarios.Any() ? _context.Usuarios.Max(u => u.Id) + 1 : 1;
        usuario.Contrasena = BCrypt.Net.BCrypt.HashPassword(usuario.Contrasena);

        // agrega al usuario
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }


    public Usuario LoginUsuario(string Email, string Contrasena)
    {
        if (string.IsNullOrEmpty(Email) ||
           string.IsNullOrEmpty(Contrasena))
            throw new Exception("Debe completar todos los campos requeridos");


        // Busca al usuario
        var usuarioEncontrado = _context.Usuarios.FirstOrDefault(u => u.Email == Email);

        // si el usuario no tiene nada no se autentica
        if (usuarioEncontrado == null)
            !BCrypt.Net.BCrypt.Verify(Contrasena, usuarioEncontrado.Contrasena);

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
        return _context.Usuarios.Select(u => new { u.Id, u.Nombre, u.Email }).ToList<object>();
    }

}

