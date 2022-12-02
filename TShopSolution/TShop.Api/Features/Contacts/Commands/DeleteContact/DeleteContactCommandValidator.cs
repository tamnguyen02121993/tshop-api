using FluentValidation;

namespace TShop.Api.Features.Contacts.Commands.DeleteContact;

public class DeleteContactCommandValidator: AbstractValidator<DeleteContactCommand>
{
    public DeleteContactCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}