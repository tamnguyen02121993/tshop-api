using ErrorOr;
using MediatR;
using TShop.Contracts.Category;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommand : IRequest<ErrorOr<CategoryResponse>>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public Status Status { get; set; }
}
