using Microsoft.EntityFrameworkCore;
using ecommerce.Infrastructure.Data;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register the DbContext (using SQLite for this example)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
   
     // The "Data Source" for both UIs
    app.MapOpenApi(); 

    // SET UP 1: Scalar UI (Modern)
    // Access at: http://localhost:PORT/scalar/v1
    app.MapScalarApiReference(options => {
        options.WithTitle("E-Commerce API - Scalar View")
               .WithTheme(ScalarTheme.Moon);
    });

    // SET UP 2: Swagger UI (Classic)
    // Access at: http://localhost:PORT/swagger
    app.UseSwaggerUI(options => {
        // We must point Swagger to the .NET 10 OpenAPI JSON path
        options.SwaggerEndpoint("/openapi/v1.json", "E-Commerce API v1");
        options.RoutePrefix = "swagger"; 
    });
}

app.Run();
// ... rest of your middleware
