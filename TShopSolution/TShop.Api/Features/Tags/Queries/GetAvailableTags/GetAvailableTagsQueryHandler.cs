using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Tags;
using TShop.Contracts.Tag;

namespace TShop.Api.Features.Tags.Queries.GetAvailableTags;

public class GetAvailableTagsQueryHandler : IRequestHandler<GetAvailableTagsQuery, List<TagResponse>>
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    public GetAvailableTagsQueryHandler(ITagRepository tagRepository, IMapper mapper)
    {
        _mapper = mapper;
        _tagRepository = tagRepository;
    }
    public async Task<List<TagResponse>> Handle(GetAvailableTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await _tagRepository.GetAvailableTags().ToListAsync();
        return _mapper.Map<List<TagResponse>>(tags); 
    }
}