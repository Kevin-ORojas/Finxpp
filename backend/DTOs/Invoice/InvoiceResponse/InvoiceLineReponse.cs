namespace backend.DTOs;

public class InvoiceLineResponse
{
    public int InvoiceId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public decimal Total { get; set; }
    public List<InvoiceLineResponse> Items { get; set; } = new();

}