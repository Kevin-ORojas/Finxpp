using Microsoft.AspNetCore.Mvc;
using backend.Models;
using backend.Services;


namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalariosController : ControllerBase
    {
        private readonly SalarioService _service;

        public SalariosController(SalarioService service)
        {
            _service = service;
        }

        [HttpPost("NuevoSalario")]

        public async Task<IActionResult> NuevoSalario([FromBody] Salario salario)
        {
            var salarioCreado = await _service.CrearSalario(salario);
            return CreatedAtAction(nameof(NuevoSalario), new { id = salarioCreado.Id }, salarioCreado);

        }

    }
}