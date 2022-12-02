using ErrorOr;
using MediatR;

namespace TShop.Api.Features.Contacts.Commands.DeleteContact;

public class DeleteContactCommand: IRequest<ErrorOr<Deleted>>
{
    public Guid Id { get; set; }
}