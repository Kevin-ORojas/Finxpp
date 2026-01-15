namespace backend.DTOs;

public class CreateInvoiceRequest
{
    public string CustomerName { get; set; } = string.Empty;
    public List<CreateInvoiceItemRequest> Items { get; set; } = new();

}