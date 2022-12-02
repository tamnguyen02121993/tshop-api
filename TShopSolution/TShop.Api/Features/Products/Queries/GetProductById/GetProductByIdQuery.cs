using ErrorOr;
using MediatR;
using TShop.Contracts.Product;

namespace TShop.Api.Features.Products.Queries.GetProductById;

public class GetProductByIdQuery: IRequest<ErrorOr<ProductResponse>>
{
    public Guid Id { get; set; }
}
