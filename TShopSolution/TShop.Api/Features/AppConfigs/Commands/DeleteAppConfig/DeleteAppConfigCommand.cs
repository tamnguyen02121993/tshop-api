using ErrorOr;
using MediatR;

namespace TShop.Api.Features.AppConfigs.Commands.DeleteAppConfig;

public class DeleteAppConfigCommand: IRequest<ErrorOr<Deleted>>
{
    public int Id { get; set; }
}