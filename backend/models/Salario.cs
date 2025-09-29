namespace backend.Models;

public class Salario
{
    public int Id { get; set; } = 0;

    public int UsuarioId { get; set; } = 0;

    public decimal Monto { get; set; } = 0;
}