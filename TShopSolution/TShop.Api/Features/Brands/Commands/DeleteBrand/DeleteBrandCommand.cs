using ErrorOr;
using MediatR;

namespace TShop.Api.Features.Brands.Commands.DeleteBrand;

public class DeleteBrandCommand: IRequest<ErrorOr<Deleted>>
{
    public int Id { get; set; }
}