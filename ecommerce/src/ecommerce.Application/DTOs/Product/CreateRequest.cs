
namespace ecommerce.Application.DTOs;

public record CreateProductRequest(
    string Name,
    string? Description,
    decimal Price,
    string Category,
    string? ImageUrl,
    int StockQuantity
);
