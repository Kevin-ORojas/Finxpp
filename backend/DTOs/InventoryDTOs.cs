namespace backend.DTOs;

public record InventoryRequest(
    string Name,
    string Description,
    int Quantity,
    decimal Price
    );

public record InventoryResponse(
    int Id, 
    string Name,
    string Description,
    decimal Price,
    int Quantity
    );