using backend.Data;
using backend.DTOs;
using backend.Models;
using backend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class InventoryService : IInventoryService
{
    private readonly AppDbContext _context;

    public InventoryService(AppDbContext context)
    {
        _context = context;
    }

    //! crea un objeto de tipo InventoryResponse por cada inventario en la base de datos
    public async Task<List<InventoryResponse>> ListInventories()
    {
        return await _context.Inventories.Select(i => new InventoryResponse(
            i.Id,
            i.Name,
            i.Description,
            i.Price,
            i.Quantity)).ToListAsync();
    }

    public async Task<InventoryResponse> GetInventory(int id)   // ✅ implementación que faltaba
    {
        var inventory = await _context.Inventories.FindAsync(id)
            ?? throw new Exception("Inventory not found");

        return new InventoryResponse(
            inventory.Id,
            inventory.Name,
            inventory.Description,
            inventory.Price,
            inventory.Quantity);
    }


    public async Task<InventoryResponse> CreateInventory(InventoryRequest request)
    {


        string name = request.Name?.Trim() ?? "";

        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("Name cannot be empty");
        }
        name = name.ToLower();

        bool exits = await _context.Inventories.AnyAsync(i => i.Name == name);
        if (exits)
        {
            throw new Exception("Inventory with the same name already exists");
        }

        if (request.Quantity < 0)
        {
            throw new Exception("Quantity cannot be negative");
        }

        if (request.Price <= 0)
        {
            throw new Exception("Price cannot be negative");
        }

        var inventory = new Inventory
        {
            Name = name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity
        };


        try
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            throw new InvalidOperationException("Inventory name already exists (DB constraint)");
        }

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
        var inventory = await _context.Inventories.FindAsync(id)
            ?? throw new Exception("Inventory not found");

        _context.Inventories.Remove(inventory);
        await _context.SaveChangesAsync();
    }

    public async Task<InventoryResponse> UpdateInventory(int id, InventoryRequest request)
    {
        var inventory = await _context.Inventories.FindAsync(id)
            ?? throw new Exception("Inventory not found");

        if (request.Quantity < 0)
        {
            throw new Exception("Quantity cannot be negative");
        }

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

