using ErrorOr;
using MediatR;
using TShop.Contracts.Authentication;

namespace TShop.Api.Features.Authentication.Queries.GetUserByEmail;

public class GetUserByEmailQuery: IRequest<ErrorOr<UserResponse>>
{
    public string Email { get; set; } = string.Empty;
}
