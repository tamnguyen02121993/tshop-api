using ErrorOr;
using MediatR;

namespace TShop.Api.Features.Tags.Commands.DeleteTag;

public class DeleteTagCommand: IRequest<ErrorOr<Deleted>>
{
    public int Id { get; set; }
}