using MapsterMapper;
using MediatR;
using TShop.Api.Repositories.Contacts;
using TShop.Contracts.Contact;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Contacts.Queries.GetAllContactsPagination;

public class GetAllContactsPaginationQueryHandler : IRequestHandler<GetAllContactsPaginationQuery, Pagination<ContactResponse>>
{
    private readonly IContactRepository _brandRepository;
    private readonly IMapper _mapper;
    public GetAllContactsPaginationQueryHandler(IContactRepository brandRepository, IMapper mapper)
    {
        _brandRepository = brandRepository;
        _mapper = mapper;
    }
    public async Task<Pagination<ContactResponse>> Handle(GetAllContactsPaginationQuery request, CancellationToken cancellationToken)
    {
        var brands = await _brandRepository.GetAllContacts(request.PageIndex, request.PageSize, request.Search);
        var brandsResponse = _mapper.Map<Pagination<ContactResponse>>(brands);

        return brandsResponse;
    }
}
