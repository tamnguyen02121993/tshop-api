using MediatR;
using TShop.Contracts.Product;

namespace TShop.Api.Features.Products.Queries.GetAvailableProducts;

public class GetAvailableProductsQuery: IRequest<List<ProductResponse>>
{
}
