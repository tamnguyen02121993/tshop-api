using ErrorOr;
using MediatR;
using TShop.Contracts.Category;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<ErrorOr<CategoryResponse>>
{
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Status Status { get; set; }
}
