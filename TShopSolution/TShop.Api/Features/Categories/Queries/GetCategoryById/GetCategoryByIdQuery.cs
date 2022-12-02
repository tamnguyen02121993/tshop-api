using ErrorOr;
using MediatR;
using TShop.Contracts.Category;

namespace TShop.Api.Features.Categories.Queries.GetCategoryById;

public class GetCategoryByIdQuery : IRequest<ErrorOr<CategoryResponse>>
{
    public int Id { get; set; }
}
