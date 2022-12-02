using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Tags;
using TShop.Contracts.Tag;
using TShop.Api.ServiceErrors;
using TShop.Api.Models;

namespace TShop.Api.Features.Tags.Commands.UpdateTag;

public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, ErrorOr<TagResponse>>
{
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    
    public UpdateTagCommandHandler(ITagRepository tagRepository, IMapper mapper)
    {
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<TagResponse>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.GetTagById(request.Id);
        if (tag is null)
        {
            return Errors.Tag.NotFound;
        }

        var updatedTag = _mapper.Map<UpdateTagCommand, Tag>(request, tag);
        await _tagRepository.UpdateTag(updatedTag);

        return _mapper.Map<TagResponse>(updatedTag);
    }
}