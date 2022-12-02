using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Tags;
using TShop.Contracts.Tag;

namespace TShop.Api.Features.Tags.Queries.GetAllTags;

public class GetAllContactsQueryHandler : IRequestHandler<GetAllTagsQuery, List<TagResponse>>
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    public GetAllContactsQueryHandler(ITagRepository tagRepository, IMapper mapper)
    {
        _mapper = mapper;
        _tagRepository = tagRepository;
    }
    public async Task<List<TagResponse>> Handle(GetAllTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = await _tagRepository.GetAllTags().ToListAsync();
        return _mapper.Map<List<TagResponse>>(tags); 
    }
}