using backend.DTOs;

namespace backend.Models;

public interface IInvoiceService
{
    Task<int> CreateInvoice(CreateInvoiceRequest request);
}