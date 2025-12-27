using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Services.Interfaces;

namespace backend.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    public List<InventoryResponse> ListInventories()
    {
        return _context.Inventories.Select(i => new InventoryResponse(
            i.Id,
            i.Name,
            i.Description,
            i.Price,
            i.Quantity)).ToList();
    }

    public InventoryResponse GetInventory(int id)   // ✅ implementación que faltaba
    {
        var inventory = _context.Inventories.Find(id)
            ?? throw new Exception("Inventario no encontrado");

        return new InventoryResponse(
            inventory.Id,
            inventory.Name,
            inventory.Description,
            inventory.Price,
            inventory.Quantity);
    }


    public InventoryResponse CreateInventory(InventoryRequest request)
    {
        var inventory = new Inventory
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity
        };
        _context.Inventories.Add(inventory);
        _context.SaveChanges();

        return new InventoryResponse(
            inventory.Id,
            inventory.Name,
            inventory.Description,
            inventory.Price,
            inventory.Quantity
            );
    }
};

