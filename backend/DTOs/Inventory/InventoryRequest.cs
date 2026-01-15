namespace backend.DTOs;

public record InventoryRequest(
    string Name,
    string Description,
    int Quantity,
    decimal Price
    );