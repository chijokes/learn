

using ecommerce.Application.DTOs;
using ecommerce.Domain.Entities;
using ecommerce.Infrastructure.Data;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ecommerce.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController(AppDbContext context) : ControllerBase
{
    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductResponse>>> GetProducts()
    {
        var products = await context.Products.ToListAsync();
        
        // Use Mapster to convert the list of Entities to a list of DTOs
        return Ok(products.Adapt<IEnumerable<ProductResponse>>());
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<ProductResponse>> CreateProduct(CreateProductRequest request)
    {
        // 1. Map DTO to Entity
        var product = request.Adapt<Product>();

        // 2. Save to Database
        context.Products.Add(product);
        await context.SaveChangesAsync();

        // 3. Map Entity back to Response DTO
        var response = product.Adapt<ProductResponse>();

        return CreatedAtAction(nameof(GetProducts), new { id = response.Id }, response);
    }
}
