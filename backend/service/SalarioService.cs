using backend.Models;
using backend.Data;
using Microsoft.EntityFrameworkCore;


namespace backend.Services
{
    public class SalarioService
    {
        private readonly AppDbContext _context;

        public SalarioService(AppDbContext context)
        {
            _context = context;
        }

        // crear un salario
        public async Task<Salario> CrearSalario(Salario salario)
        {
            _context.Salarios.Add(salario);
            await _context.SaveChangesAsync();
            return salario;
        }
        //leer todos
        public async Task<List<Salario>> ObtenerSalarios()
        {
            return await _context.Salarios.ToListAsync();
        }

        //leer por id
        public async Task<Salario> ObtenerSalario(int id)
        {
            return await _context.Salarios.FindAsync(id);
        }

        public async Task<Salario> ActualizarSalario(Salario salario)
        {
            _context.Salarios.Update(salario);
            await _context.SaveChangesAsync();
            return salario;
        }

        public async Task<bool> EliminarSalario(int id)
        {
            var salario = await _context.Salarios.Remove(salario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}