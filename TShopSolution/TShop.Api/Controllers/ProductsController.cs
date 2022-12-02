using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TShop.Api.Features.AppConfigs.Queries.GetAllAppConfigs;
using TShop.Api.Features.AppConfigs.Queries.GetAvailableAppConfigs;
using TShop.Api.Features.Products.Commands.CreateProduct;
using TShop.Api.Features.Products.Commands.DeleteProduct;
using TShop.Api.Features.Products.Commands.UpdateProduct;
using TShop.Api.Features.Products.Commands.UpdateProductImages;
using TShop.Api.Features.Products.Queries.GetAllProducts;
using TShop.Api.Features.Products.Queries.GetAvailableProducts;
using TShop.Api.Features.Products.Queries.GetProductById;
using TShop.Contracts.AppConfig;
using TShop.Contracts.Product;

namespace TShop.Api.Controllers;

public class ProductsController: ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    public ProductsController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(CreateProductRequest request)
    {
        ErrorOr<ProductResponse> createProductResult = await _sender.Send(_mapper.Map<CreateProductCommand>(request));

        return createProductResult.Match(
            product => CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:Guid}")]
    public async Task<IActionResult> GetProductById([FromRoute] Guid id)
    {
        ErrorOr<ProductResponse> getProductResult = await _sender.Send(new GetProductByIdQuery
        {
            Id = id,
        });

        return getProductResult.Match(
            product => Ok(product),
            errors => Problem(errors)
        );
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllProducts()
    {
        List<ProductResponse> products = await _sender.Send(new GetAllProductsQuery());

        return Ok(products);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableProducts()
    {
        List<ProductResponse> products = await _sender.Send(new GetAvailableProductsQuery());

        return Ok(products);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductRequest request)
    {
        ErrorOr<ProductResponse> updateProductResult = await _sender.Send(_mapper.Map<UpdateProductCommand>(request));

        return updateProductResult.Match(
            product => Ok(product),
            errors => Problem(errors)
        );
    }

    [HttpPut("images")]
    public async Task<IActionResult> UpdateProductImages([FromBody] UpdateProductImagesRequest request)
    {
        ErrorOr<ProductResponse> updateProductResult = await _sender.Send(_mapper.Map<UpdateProductImagesCommand>(request));

        return updateProductResult.Match(
            product => Ok(product),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:Guid}")]
    public async Task<IActionResult> DeleteProduct([FromRoute] Guid id)
    {
        ErrorOr<Deleted> deleteProductResult = await _sender.Send(new DeleteProductCommand()
        {
            Id = id
        });
        return deleteProductResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }
}
