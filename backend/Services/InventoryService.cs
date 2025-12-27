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

    public async Task<List<InventoryResponse>> ListInventories()
    {
        return _context.Inventories.Select(i => new InventoryResponse(
            i.Id,
            i.Name,
            i.Description,
            i.Price,
            i.Quantity)).ToList();
    }

    public async Task<InventoryResponse> GetInventory(int id)   // ✅ implementación que faltaba
    {
        var inventory = await _context.Inventories.FindAsync(id)
            ?? throw new Exception("Inventario no encontrado");

        return new InventoryResponse(
            inventory.Id,
            inventory.Name,
            inventory.Description,
            inventory.Price,
            inventory.Quantity);
    }


    public async Task<InventoryResponse> CreateInventory(InventoryRequest request)
    {
        var inventory = new Inventory
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity
        };
        _context.Inventories.Add(inventory);
        await _context.SaveChangesAsync();

        return new InventoryResponse(
            inventory.Id,
            inventory.Name,
            inventory.Description,
            inventory.Price,
            inventory.Quantity
            );
    }

    public async Task DeleteInventory(int id)
    {
        var inventory = _context.Inventories.Find(id)
            ?? throw new Exception("Inventario no encontrado");

        _context.Inventories.Remove(inventory);
        await _context.SaveChangesAsync();
    }

    public async Task<InventoryResponse> UpdateInventory(int id, InventoryRequest request)
    {
        var inventory = await _context.Inventories.FindAsync(id)
            ?? throw new Exception("Inventario no encontrado");

        inventory.Name = request.Name;
        inventory.Description = request.Description;
        inventory.Price = request.Price;
        inventory.Quantity = request.Quantity;

        await _context.SaveChangesAsync();

        return new InventoryResponse(
            inventory.Id,
            inventory.Name,
            inventory.Description,
            inventory.Price,
            inventory.Quantity
            );
    }
};

