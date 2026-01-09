using ecommerce.Application.DTOs;
using ecommerce.Application.DTOs.Product;
using ecommerce.Domain.Entities;
using Mapster;

namespace ecommerce.Application.Mappers;

public class MapsterProfile : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // Map from CreateProductRequest to Product
        config.NewConfig<CreateProductRequest, Product>();

        // Map from Product to ProductResponse
        config.NewConfig<Product, ProductResponse>();
    }
}

