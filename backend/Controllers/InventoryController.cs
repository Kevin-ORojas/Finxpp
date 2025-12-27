
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
    public ActionResult<List<InventoryResponse>> GetAll() => _service.ListInventories();

    [HttpGet("{id}")]
    public ActionResult<InventoryResponse> Get(int id) => _service.GetInventory(id);

    [HttpPost]
    public ActionResult<InventoryResponse> Create(InventoryRequest request) => _service.CreateInventory(request);

    //[HttpPut("{id}")]

    //[HttpDelete("{id}")]
}