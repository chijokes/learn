

namespace ecommerce.Application.DTOs.Product;

public record ProductResponse(
    int Id,
    string Name,
    string? Description,
    decimal Price,
    string Category,
    string? ImageUrl,
    int StockQuantity
);
