using FluentValidation;

namespace TShop.Api.Features.Contacts.Queries.GetContactById;

public class GetContactByIdQueryValidator: AbstractValidator<GetContactByIdQuery>
{
    public GetContactByIdQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}