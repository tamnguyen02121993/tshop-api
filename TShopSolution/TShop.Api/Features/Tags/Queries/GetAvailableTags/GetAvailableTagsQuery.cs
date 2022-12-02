using MediatR;
using TShop.Contracts.Tag;

namespace TShop.Api.Features.Tags.Queries.GetAvailableTags;

public class GetAvailableTagsQuery: IRequest<List<TagResponse>>
{
    
}