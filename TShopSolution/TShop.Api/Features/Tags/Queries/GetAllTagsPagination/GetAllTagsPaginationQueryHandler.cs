using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Tags;
using TShop.Contracts.Tag;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Tags.Queries.GetAllTagsPagination;

public class GetAllTagsPaginationQueryHandler : IRequestHandler<GetAllTagsPaginationQuery, Pagination<TagResponse>>
{
    private readonly ITagRepository _brandRepository;
    private readonly IMapper _mapper;
    public GetAllTagsPaginationQueryHandler(ITagRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<TagResponse>> Handle(GetAllTagsPaginationQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAllTags(request.PageIndex, request.PageSize, request.Search);
        var brandsResponse = _mapper.Map<Pagination<TagResponse>>(brands);

        return brandsResponse;
    }
}
