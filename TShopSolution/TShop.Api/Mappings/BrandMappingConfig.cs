using Mapster;
using TShop.Api.Features.Brands.Commands.CreateBrand;
using TShop.Api.Features.Brands.Commands.UpdateBrand;
using TShop.Api.Features.Brands.Queries.GetAllBrandsPagination;
using TShop.Api.Features.Brands.Queries.GetAvailableBrandsPagination;
using TShop.Api.Models;
using TShop.Contracts.Brand;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Mappings;

public class BrandMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateBrandRequest, CreateBrandCommand>();
        config.NewConfig<UpdateBrandRequest, UpdateBrandCommand>().IgnoreNullValues(true);
        config.NewConfig<UpdateBrandCommand, Brand>().IgnoreNullValues(true);
        config.NewConfig<Pagination<Brand>, Pagination<BrandResponse>>().IgnoreNullValues(true);
        config.NewConfig<Brand, BrandResponse>();
    }
}
