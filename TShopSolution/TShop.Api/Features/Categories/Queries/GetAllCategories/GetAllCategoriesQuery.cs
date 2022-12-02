using MediatR;
using TShop.Contracts.Category;

namespace TShop.Api.Features.Categories.Queries.GetAllCategories;

public class GetAllCategoriesQuery : IRequest<List<CategoryResponse>>
{
}