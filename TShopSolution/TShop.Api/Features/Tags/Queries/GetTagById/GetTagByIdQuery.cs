using ErrorOr;
using MediatR;
using TShop.Contracts.Tag;

namespace TShop.Api.Features.Tags.Queries.GetTagById;

public class GetTagByIdQuery: IRequest<ErrorOr<TagResponse>>
{
    public int Id { get; set; }
}