using MediatR;
using TShop.Contracts.Contact;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Features.Contacts.Queries.GetAllContactsPagination;

public class GetAllContactsPaginationQuery : IRequest<Pagination<ContactResponse>>
{
    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public string? Search { get; set; }
}
