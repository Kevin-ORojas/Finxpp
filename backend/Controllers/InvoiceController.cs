

using backend.DTOs;
using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Namespace.DTOs;

[ApiController]
[Route("api/[controller]")]
public class InvoiceController : ControllerBase
{
    private readonly IInvoiceService _invoiceService;

    public InvoiceController(IInvoiceService invoiceService)
    {
        _invoiceService = invoiceService;
    }


    [HttpPost]
    public async Task<ActionResult<InvoiceResponse>> Create([FromBody] CreateInvoiceRequest request)
    {
        try
        {
            var invoiceId = await _invoiceService.CreateInvoice(request);
            return Ok(new { InvoiceId = invoiceId });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }

}