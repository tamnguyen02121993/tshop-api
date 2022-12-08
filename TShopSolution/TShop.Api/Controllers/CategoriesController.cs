using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using TShop.Contracts.Category;
using MediatR;
using TShop.Api.Features.Categories.Commands.CreateCategory;
using MapsterMapper;
using TShop.Api.Features.Categories.Queries.GetCategoryById;
using TShop.Api.Features.Categories.Commands.DeleteCategory;
using TShop.Api.Features.Categories.Commands.UpdateCategory;
using TShop.Api.Features.Categories.Queries.GetAvailableCategories;
using TShop.Api.Features.Categories.Queries.GetAllCategories;
using TShop.Contracts.Utils.Commons;
using TShop.Api.Features.Categories.Queries.GetAvailableCategoriesPagination;
using TShop.Api.Features.Categories.Queries.GetAllCategoriesPagination;
using Microsoft.AspNetCore.Authorization;

namespace TShop.Api.Controllers;

[Authorize]
public class CategoriesController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;
    public CategoriesController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest request)
    {
        ErrorOr<CategoryResponse> createdCategoryResult = await _sender.Send(_mapper.Map<CreateCategoryCommand>(request));

        return createdCategoryResult.Match(
            category => CreatedAtGetCategory(category),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCategory([FromRoute] int id)
    {
        ErrorOr<CategoryResponse> getCategoryResult = await _sender.Send(new GetCategoryByIdQuery
        {
            Id = id,
        });

        return getCategoryResult.Match(
            category => Ok(category),
            errors => Problem(errors)
        );
    }

    [HttpGet("all")]
    public async Task<IActionResult> GetAllCategories()
    {
        List<CategoryResponse> categories = await _sender.Send(new GetAllCategoriesQuery());

        return Ok(categories);
    }

    [HttpGet("all-pagination")]
    public async Task<IActionResult> GetAllCategoriesPagination([FromQuery] int pageIndex, [FromQuery] string? search, [FromQuery] int pageSize = Constants.DEFAULT_PAGESIZE)
    {
        Pagination<CategoryResponse> categories = await _sender.Send(new GetAllCategoriesPaginationQuery
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Search = search
        });

        return Ok(categories);
    }

    [HttpGet("available")]
    public async Task<IActionResult> GetAvailableCategories()
    {
        List<CategoryResponse> categories = await _sender.Send(new GetAvailableCategoriesQuery());

        return Ok(categories);
    }

    [HttpGet("available-pagination")]
    public async Task<IActionResult> GetAvailableCategoriesPagination([FromQuery] int pageIndex, [FromQuery] string? search, [FromQuery] int pageSize = Constants.DEFAULT_PAGESIZE)
    {
        Pagination<CategoryResponse> categories = await _sender.Send(new GetAvailableCategoriesPaginationQuery
        {
            PageIndex = pageIndex,
            PageSize = pageSize,
            Search = search
        });

        return Ok(categories);
    }

    [HttpPut()]
    public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryRequest request)
    {
        ErrorOr<CategoryResponse> updateCategoryResult = await _sender.Send(_mapper.Map<UpdateCategoryCommand>(request));

        return updateCategoryResult.Match(
            category => Ok(category),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCategory([FromRoute] int id)
    {
        ErrorOr<Deleted> deleteCategoryResult = await _sender.Send(new DeleteCategoryCommand()
        {
            Id = id
        });
        return deleteCategoryResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private CreatedAtActionResult CreatedAtGetCategory(CategoryResponse response)
    {
        return CreatedAtAction(
                    actionName: nameof(GetCategory),
                    routeValues: new { id = response.Id },
                    value: response);
    }
}