using FluentValidation;

namespace TShop.Api.Features.Tags.Commands.DeleteTag;

public class DeleteTagCommandValidator: AbstractValidator<DeleteTagCommand>
{
    public DeleteTagCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}