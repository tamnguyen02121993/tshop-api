using ErrorOr;
using MediatR;
using TShop.Contracts.AppConfig;
using TShop.Contracts.Tag;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.Features.AppConfigs.Commands.UpdateAppConfig;

public class UpdateAppConfigCommand: IRequest<ErrorOr<AppConfigResponse>>
{
    public int Id { get; set; }
    public string Key { get; set; } = string.Empty;
    public string Value { get; set; } = string.Empty;
    public Status Status { get; set; }
}