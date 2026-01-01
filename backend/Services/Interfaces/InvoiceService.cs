using backend.Models;

public interface IInvoiceService
{
    Task<Invoice> CreateInvoiceAsync(CreateInvoiceRequest request);
}