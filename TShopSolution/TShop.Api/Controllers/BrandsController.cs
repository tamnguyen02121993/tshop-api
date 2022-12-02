using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TShop.Api.Features.Brands.Commands.CreateBrand;
using TShop.Api.Features.Brands.Commands.DeleteBrand;
using TShop.Api.Features.Brands.Commands.UpdateBrand;
using TShop.Api.Features.Brands.Queries.GetAllBrands;
using TShop.Api.Features.Brands.Queries.GetAllBrandsPagination;
using TShop.Api.Features.Brands.Queries.GetAvailableBrands;
using TShop.Api.Features.Brands.Queries.GetAvailableBrandsPagination;
using TShop.Api.Features.Brands.Queries.GetBrandById;
using TShop.Contracts.Brand;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Controllers;

public class BrandsController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    public BrandsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBrand(CreateBrandRequest request)
    {
        ErrorOr<BrandResponse> createBrandResult = await _sender.Send(_mapper.Map<CreateBrandCommand>(request));

        return createBrandResult.Match(
            brand => CreatedAtAction(nameof(GetBrandById), new { id = brand.Id }, brand),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetBrandById([FromRoute] int id)
    {
        ErrorOr<BrandResponse> getBrandResult = await _sender.Send(new GetBrandByIdQuery
        {
            Id = id,
        });

        return getBrandResult.Match(
            brand => Ok(brand),
            errors => Problem(errors)
        );
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllBrands()
    {
        List<BrandResponse> brands = await _sender.Send(new GetAllBrandsQuery());

        return Ok(brands);
    }

    [HttpGet("all-pagination")]
    public async Task<IActionResult> GetAllBrandsPagination([FromQuery] int pageIndex, [FromQuery] string? search, [FromQuery] int pageSize = Constants.DEFAULT_PAGESIZE)
    {
        Pagination<BrandResponse> brands = await _sender.Send(new GetAllBrandsPaginationQuery
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Search = search
        });

        return Ok(brands);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableBrands()
    {
        List<BrandResponse> brands = await _sender.Send(new GetAvailableBrandsQuery());

        return Ok(brands);
    }

    [HttpGet("available-pagination")]
    public async Task<IActionResult> GetAvailableBrandsPagination([FromQuery] int pageIndex, [FromQuery] string? search, [FromQuery] int pageSize = Constants.DEFAULT_PAGESIZE)
    {
        Pagination<BrandResponse> brands = await _sender.Send(new GetAvailableBrandsPaginationQuery
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Search = search
        });

        return Ok(brands);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateBrandRequest request)
    {
        ErrorOr<BrandResponse> updateBrandResult = await _sender.Send(_mapper.Map<UpdateBrandCommand>(request));

        return updateBrandResult.Match(
            brand => Ok(brand),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        ErrorOr<Deleted> deleteBrandResult = await _sender.Send(new DeleteBrandCommand()
        {
            Id = id
        });
        return deleteBrandResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
}