namespace backend.DTOs;

public record InventoryRequest(string Name, int Quantity, decimal Price);

public record InventoryResponse(int Id, string Name, decimal Price, int Quantity);