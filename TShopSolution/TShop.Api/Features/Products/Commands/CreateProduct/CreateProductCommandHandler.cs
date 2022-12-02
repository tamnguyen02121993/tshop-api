using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Models;
using TShop.Api.Repositories.Brands;
using TShop.Api.Repositories.Categories;
using TShop.Api.Repositories.Products;
using TShop.Api.Repositories.Tags;
using TShop.Api.ServiceErrors;
using TShop.Api.Utils.Extensions;
using TShop.Contracts.Product;

namespace TShop.Api.Features.Products.Commands.CreateProduct;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ErrorOr<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    public CreateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IBrandRepository brandRepository, ITagRepository tagRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _brandRepository = brandRepository;
        _tagRepository = tagRepository;
        _mapper = mapper;
    }
    public async Task<ErrorOr<ProductResponse>> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Product>(request);
        product.SeoUrl = product.Name.CreateSlugString();
        product.Viewed = 1000;
        product.Rating = 10;
        var brand = await _brandRepository.GetBrandById(request.BrandId);
        if (brand is not null)
        {
            product.Brand = brand;
        }
        var category = await _categoryRepository.GetCategoryById(request.CategoryId);
        if (category is not null)
        {
            product.Category = category;
        }
        if (request.Tags is not null)
        {
            var tags = await _tagRepository.GetTagByIds(request.Tags);
            foreach (var tag in request.Tags)
            {
                product.ProductTags.Add(new ProductTag
                {
                    Product = product,
                    Tag = tags.SingleOrDefault(x => x.Id == tag)!
                });
            }
        }

        var createdProduct = await _productRepository.CreateProduct(product);

        if (createdProduct is not null)
        {
            return _mapper.Map<ProductResponse>(createdProduct);
        }
        return Errors.Product.NotFound;
    }
}
