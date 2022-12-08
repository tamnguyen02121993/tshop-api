using ErrorOr;
using MediatR;
using TShop.Contracts.Authentication;

namespace TShop.Api.Features.Authentication.Queries.GetUserById;

public class GetUserByIdQuery: IRequest<ErrorOr<UserResponse>>
{
    public int Id { get; set; }
}
