namespace backend.DTOs;

public class CreateInvoiceRequest
{
    public string CustomerName { get; set; } = string.Empty;
    public List<InvoiceLineDTO> Lines { get; set; } = new();


}

public class CreateInvoiceItemResponse
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}






