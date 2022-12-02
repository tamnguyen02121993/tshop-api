using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Tags;
using TShop.Contracts.Tag;
using TShop.Api.ServiceErrors;
using MapsterMapper;

namespace TShop.Api.Features.Tags.Queries.GetTagById;

public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, ErrorOr<TagResponse>>
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    public GetTagByIdQueryHandler(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<TagResponse>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.GetTagById(request.Id);
        if (tag is not null)
        {
            return _mapper.Map<TagResponse>(tag);
        }

        return Errors.Tag.NotFound;
    }
}