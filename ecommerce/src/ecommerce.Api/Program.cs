using Microsoft.EntityFrameworkCore;
using ecommerce.Infrastructure.Data;
using Scalar.AspNetCore;
using Mapster;
using ecommerce.Application.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Register Mapster with custom config
var config = TypeAdapterConfig.GlobalSettings;
config.Scan(typeof(MapsterProfile).Assembly);
builder.Services.AddSingleton(config);

// Register the DbContext (using SQLite for this example)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Apply migrations automatically
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    context.Database.Migrate();
}

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
}

app.MapControllers();
app.Run();
