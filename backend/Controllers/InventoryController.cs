
using backend.DTOs;
using backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;


[ApiController]
[Route("api/[controller]")]
public class InventoryController : ControllerBase
{
    private readonly IInventoryService _service;

    public InventoryController(IInventoryService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<InventoryResponse>>> GetAll() => await _service.ListInventories();

    [HttpGet("{id}")]
    public async Task<ActionResult<InventoryResponse>> Get(int id) => await _service.GetInventory(id);

    [HttpPut("{id}")]
    public async Task<ActionResult<InventoryResponse>> Update(int id, InventoryRequest request) => await _service.UpdateInventory(id, request);

    [HttpPost]
    public async Task<ActionResult<InventoryResponse>> Create(InventoryRequest request) => await _service.CreateInventory(request);

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteInventory(id);
        return NoContent();
    }
}