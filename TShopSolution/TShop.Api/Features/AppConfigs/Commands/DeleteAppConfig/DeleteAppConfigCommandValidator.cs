using FluentValidation;

namespace TShop.Api.Features.AppConfigs.Commands.DeleteAppConfig;

public class DeleteAppConfigCommandValidator: AbstractValidator<DeleteAppConfigCommand>
{
    public DeleteAppConfigCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}