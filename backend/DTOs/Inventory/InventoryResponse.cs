namespace backend.DTOs;

public record InventoryResponse(
    int Id,
    string Name,
    string Description,
    decimal Price,
    int Quantity
    );