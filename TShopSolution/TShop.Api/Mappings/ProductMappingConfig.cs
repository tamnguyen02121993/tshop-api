using Mapster;
using TShop.Api.Features.Products.Commands.CreateProduct;
using TShop.Api.Features.Products.Commands.UpdateProduct;
using TShop.Api.Features.Products.Commands.UpdateProductImages;
using TShop.Api.Models;
using TShop.Contracts.Product;

namespace TShop.Api.Mappings;

public class ProductMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateProductRequest, CreateProductCommand>();
        config.NewConfig<UpdateProductRequest, UpdateProductCommand>().IgnoreNullValues(true);
        config.NewConfig<UpdateProductCommand, Product>().IgnoreNullValues(true);
        config.NewConfig<UpdateProductImagesRequest, UpdateProductImagesCommand>().IgnoreNullValues(true);
        config.NewConfig<UpdateProductImagesCommand, Product>().IgnoreNullValues(true);
        config.NewConfig<Product, ProductResponse>().Map(dest => dest.Tags, src => src.ProductTags.Select(x => x.TagId));
    }
}
