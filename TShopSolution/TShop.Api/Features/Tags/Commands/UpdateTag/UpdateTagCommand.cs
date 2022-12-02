using ErrorOr;
using MediatR;
using TShop.Contracts.Tag;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.Tags.Commands.UpdateTag;

public class UpdateTagCommand: IRequest<ErrorOr<TagResponse>>
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Status Status { get; set; }
}