using ErrorOr;
using MediatR;
using TShop.Contracts.Tag;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Tags.Commands.CreateTag;

public class CreateTagCommand: IRequest<ErrorOr<TagResponse>>
{
    public string Title { get; set; } = string.Empty;
    public Status Status { get; set; }
}