
using Microsoft.EntityFrameworkCore;
using ecommerce.Domain.Entities; // Important: Reference your Domain Layer

namespace ecommerce.Infrastructure.Data;

// The Primary Constructor (options) injects the database settings automatically
public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    // Every 'DbSet' represents a Table in your database
    public DbSet<Product> Products { get; set; }

    // This is where you configure advanced rules (Fluent API)
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Master Tip: Ensure Price has proper precision for money
        modelBuilder.Entity<Product>(entity =>
        {
            entity.Property(p => p.Price)
                  .HasPrecision(18, 2); // 18 digits total, 2 after decimal
            
            entity.Property(p => p.Name)
                  .HasMaxLength(200);
        });
    }
}
