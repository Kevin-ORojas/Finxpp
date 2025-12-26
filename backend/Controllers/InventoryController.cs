
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

    //[HttpGet("{id}")]

    //[HttpPost]

    //[HttpPut("{id}")]

    //[HttpDelete("{id}")]
}