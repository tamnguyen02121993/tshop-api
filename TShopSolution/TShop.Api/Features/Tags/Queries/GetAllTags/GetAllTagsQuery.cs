using MediatR;
using TShop.Contracts.Tag;

namespace TShop.Api.Features.Tags.Queries.GetAllTags;

public class GetAllTagsQuery: IRequest<List<TagResponse>>
{
    
}