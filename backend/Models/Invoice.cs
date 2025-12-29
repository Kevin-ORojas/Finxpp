namespace backend.Models;

public class Invoice
{

    // Identidad
    public int InvoiceId { get; set; }

    public int InvoiceNumber { get; set; }

    public string CustomerName { get; set; } = string.Empty;

    public bool Status { get; set; } = true;
    public decimal SubTotal { get; set; }
    public decimal Total { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
