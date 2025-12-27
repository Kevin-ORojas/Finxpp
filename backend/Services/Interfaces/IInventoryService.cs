using backend.DTOs;

namespace backend.Services.Interfaces;

public interface IInventoryService
{
    List<InventoryResponse> ListInventories();
    InventoryResponse GetInventory(int id);
    InventoryResponse CreateInventory(InventoryRequest request);
    //InventoryResponse UpdateInventory(int id, InventoryRequest request);
    //    void DeleteInventory(int id);
}