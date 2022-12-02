using FluentValidation;

namespace TShop.Api.Features.AppConfigs.Commands.UpdateAppConfig;

public class UpdateAppConfigCommandValidator: AbstractValidator<UpdateAppConfigCommand>
{
    public UpdateAppConfigCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Key).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Value).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Status).IsInEnum();
    }
}