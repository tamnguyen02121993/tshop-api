using FluentValidation;

namespace TShop.Api.Features.Contacts.Queries.GetAllContactsPagination;

public class GetAllContactsPaginationQueryValidator : AbstractValidator<GetAllContactsPaginationQuery>
{
    public GetAllContactsPaginationQueryValidator()
    {
        RuleFor(x => x.PageIndex).NotEmpty().GreaterThanOrEqualTo(0);
        RuleFor(x => x.PageSize).NotEmpty().GreaterThanOrEqualTo(1);
    }
}
