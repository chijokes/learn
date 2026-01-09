

namespace ecommerce.Domain.Entities;

public class Product
{
    // Required for Entity Framework Core
    public int Id { get; set; }

    // Use 'required' to ensure a name is always provided
    public required string Name { get; set; } 

    public string? Description { get; set; }

    // Use decimal for money to avoid rounding errors (Never use float/double)
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public required string Category { get; set; } // e.g., "Beverage", "Bakery", "Frozen"

    public string? ImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    // Metadata for 2026 auditing standards
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
}
