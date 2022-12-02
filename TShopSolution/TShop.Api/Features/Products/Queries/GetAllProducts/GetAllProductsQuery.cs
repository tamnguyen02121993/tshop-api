using MediatR;
using TShop.Contracts.Product;

namespace TShop.Api.Features.Products.Queries.GetAllProducts;

public class GetAllProductsQuery: IRequest<List<ProductResponse>>
{
}
