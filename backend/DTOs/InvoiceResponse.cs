namespace Namespace.DTOs;

public class InvoiceResponse
{
    public int InvoiceId { get; set; }
    public DateTime Date { get; set; }

    public decimal Total { get; set; }

    public required List<InvoiceLineResponse> Items { get; set; }
}


public class InvoiceLineResponse
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; }

    public decimal Price { get; set; }
}