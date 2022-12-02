using MediatR;
using TShop.Contracts.Category;

namespace TShop.Api.Features.Categories.Queries.GetAvailableCategories;

public class GetAvailableCategoriesQuery : IRequest<List<CategoryResponse>>
{
}