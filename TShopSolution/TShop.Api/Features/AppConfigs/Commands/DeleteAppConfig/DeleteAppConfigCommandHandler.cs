using ErrorOr;
using MediatR;
using TShop.Api.Repositories.AppConfigs;
using TShop.Api.ServiceErrors;

namespace TShop.Api.Features.AppConfigs.Commands.DeleteAppConfig;

public class DeleteAppConfigCommandHandler : IRequestHandler<DeleteAppConfigCommand, ErrorOr<Deleted>>
{
    private readonly IAppConfigRepository _appConfigRepository;
    public DeleteAppConfigCommandHandler(IAppConfigRepository appConfigRepository)
    {
        _appConfigRepository = appConfigRepository;
    }
    public async Task<ErrorOr<Deleted>> Handle(DeleteAppConfigCommand request, CancellationToken cancellationToken)
    {
        var appConfig = await _appConfigRepository.GetAppConfigById(request.Id);
        if (appConfig is null)
        {
            return Errors.AppConfig.NotFound;
        }
        await _appConfigRepository.DeleteAppConfig(appConfig);

        return Result.Deleted;
    }
}