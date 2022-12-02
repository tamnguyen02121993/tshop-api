using ErrorOr;
using MediatR;
using TShop.Contracts.AppConfig;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.AppConfigs.Commands.CreateAppConfig;

public class CreateAppConfigCommand: IRequest<ErrorOr<AppConfigResponse>>
{
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public Status Status { get; set; }
}