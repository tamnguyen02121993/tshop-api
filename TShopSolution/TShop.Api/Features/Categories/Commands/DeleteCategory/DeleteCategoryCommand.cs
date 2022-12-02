using ErrorOr;
using MediatR;

namespace TShop.Api.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand : IRequest<ErrorOr<Deleted>>
{
    public int Id { get; set; }
}