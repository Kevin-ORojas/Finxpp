using backend.DTOs;

namespace backend.Services.Interfaces
{
    public interface ISalarioService
    {
        Task CrearSalario(NuevoSalario nuevoSalario);
        Task<List<SalarioDTOs>> ListarSalarioUsuario(int usuarioId);
        Task EliminarSalario(int id);
    }
}