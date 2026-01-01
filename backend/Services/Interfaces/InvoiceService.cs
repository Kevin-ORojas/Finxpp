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
        // 1. crear invoice
        var invoice = new Invoice
        {
            CreatedAt = DateTime.Now,
            CustomerName = request.CustomerName,
        };

        decimal total = 0;

        // 2. recorrer items
        foreach (var item in request.Items)
        {
            // 3. buscar inventario
            var inventory = await _context.Inventories.FindAsync(item.InventoryId);

            if (inventory == null)
            {
                throw new Exception("Inventory not found for product ID: " + item.name);
            }

            if (inventory.Quantity < item.Quantity)
            {
                throw new Exception("Insufficient stock for product ID: " + item.name);

            }

            //3. descontar del inventario
            inventory.Quantity -= item.Quantity;

        }
        invoice.Total = total;

        // ⬅️ agregar invoice al contexto
        _context.Invoices.Add(invoice);

        // ⬅️ guardar TODO (invoice + inventory)
        await _context.SaveChangesAsync();

        return invoice.InvoiceId;
    }
}