using System.Text;
using backend.Data;
using backend.DTOs;
using backend.Models;
public class InvoiceService : IInvoiceService
{
    private readonly AppDbContext _context;

    public InvoiceService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<int> CreateInvoice(CreateInvoiceRequest request)
    {
        decimal total = 0m;

        try
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request), "Request cannot be null");
            }
            if (string.IsNullOrWhiteSpace(request.CustomerName))
            {
                throw new ArgumentException("Customer name is required", nameof(request.CustomerName));
            }
            if (request.Items == null || !request.Items.Any())
            {
                throw new ArgumentException("At least one invoice item is required", nameof(request.Items));
            }

            var invoice = new Invoice
            {
                CustomerName = request.CustomerName,
                CreatedAt = DateTime.UtcNow,
                InvoiceLines = new List<InvoiceLine>()
            };
            foreach (var item in request.Items)
            {
                if (item.Quantity <= 0)
                {
                    throw new ArgumentException("Item quantity must be greater than zero", nameof(item.Quantity));
                }
                if (item.InventoryId <= 0)
                {
                    throw new ArgumentException("Item InventoryId cannot be negative", nameof(item.InventoryId));
                }

                var Inventory = await _context.Inventories.FindAsync(item.InventoryId);
                if (Inventory == null)
                {
                    throw new Exception("Inventory not found with ID: " + item.InventoryId);
                }

                if (Inventory.Quantity < item.Quantity)
                {
                    throw new Exception($"Insufficient inventory for item ID {item.InventoryId}. Available: {Inventory.Quantity}, Requested: {item.Quantity}");
                }


                var invoiceLine = new InvoiceLine
                {
                    Invoice = invoice,
                    Inventory = Inventory,
                    InventoryId = Inventory.Id,
                    Description = Inventory.Name,
                    Quantity = item.Quantity,
                    UnitPrice = Inventory.Price,
                };

                invoice.InvoiceLines.Add(invoiceLine);

                total += Inventory.Price * item.Quantity;
                Inventory.Quantity -= item.Quantity;

            }

            invoice.SubTotal = total;
            invoice.Total = total;

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return invoice.InvoiceId;
        }
        catch (Exception ex)
        {
            throw new Exception("Error creating invoice: " + ex.Message, ex);
        }

    }
}
