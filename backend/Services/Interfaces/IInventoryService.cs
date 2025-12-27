using backend.DTOs;

namespace backend.Services.Interfaces;

public interface IInventoryService
{
    Task<List<InventoryResponse>> ListInventories();
    Task<InventoryResponse> GetInventory(int id);
    Task<InventoryResponse> CreateInventory(InventoryRequest request);
    Task<InventoryResponse> UpdateInventory(int id, InventoryRequest request);
    Task DeleteInventory(int id);
}