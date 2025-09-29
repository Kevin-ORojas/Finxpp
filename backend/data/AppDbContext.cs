using Microsoft.EntityFrameworkCore;
using backend.Models;


namespace backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Salario> Salarios { get; set; }
}
