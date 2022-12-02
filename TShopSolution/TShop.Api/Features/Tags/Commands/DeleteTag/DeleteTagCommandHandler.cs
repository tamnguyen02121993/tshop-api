using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Tags;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.Tags.Commands.DeleteTag;

public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, ErrorOr<Deleted>>
{
    private readonly ITagRepository _tagRepository;
    public DeleteTagCommandHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var tag = await _tagRepository.GetTagById(request.Id);
        if (tag is null)
        {
            return Errors.Tag.NotFound;
        }
        await _tagRepository.DeleteTag(tag);

        return Result.Deleted;
    }
}