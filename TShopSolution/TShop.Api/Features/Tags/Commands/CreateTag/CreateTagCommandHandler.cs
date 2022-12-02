using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Models;
using TShop.Api.ServiceErrors;
using TShop.Contracts.Tag;
using TShop.Api.Repositories.Tags;

namespace TShop.Api.Features.Tags.Commands.CreateTag;

public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, ErrorOr<TagResponse>>
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    public CreateTagCommandHandler(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<TagResponse>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = _mapper.Map<Tag>(request);

        var createdTag = await _tagRepository.CreateTag(tag);

        if (createdTag is not null)
        {
            return _mapper.Map<TagResponse>(createdTag);
        }

        return Errors.Tag.NotFound;
    }
}