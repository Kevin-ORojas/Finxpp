using Microsoft.EntityFrameworkCore;
using Users.Models;

namespace Users.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbcontextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}