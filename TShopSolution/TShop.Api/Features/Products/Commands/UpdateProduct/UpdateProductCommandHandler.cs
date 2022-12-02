using ErrorOr;
using MapsterMapper;
using MediatR;
using TShop.Api.Models;
using TShop.Api.Repositories.Brands;
using TShop.Api.Repositories.Categories;
using TShop.Api.Repositories.Products;
using TShop.Api.Repositories.Tags;
using TShop.Api.ServiceErrors;
using TShop.Api.Utils.Extensions;
using TShop.Contracts.Product;

namespace TShop.Api.Features.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ErrorOr<ProductResponse>>
{
    private readonly IProductRepository _productRepository;
    private readonly IBrandRepository _brandRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IMapper _mapper;
    public UpdateProductCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository, IBrandRepository brandRepository, ITagRepository tagRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _brandRepository = brandRepository;
        _tagRepository = tagRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<ProductResponse>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProductById(request.Id);
        if (product is null)
        {
            return Errors.Product.NotFound;
        }
        var shouldUpdateBrand = request.BrandId != product.BrandId;
        var shouldUpdateCategory = request.CategoryId != product.CategoryId;

        var updatedProduct = _mapper.Map<UpdateProductCommand, Product>(request, product);
        updatedProduct.SeoUrl = updatedProduct.Name.CreateSlugString();
        if (shouldUpdateBrand)
        {
            var brand = await _brandRepository.GetBrandById(request.BrandId);
            if (brand is not null)
            {
                updatedProduct.Brand = brand;
            }
        }

        if(shouldUpdateCategory)
        {
            var category = await _categoryRepository.GetCategoryById(request.CategoryId);
            if (category is not null)
            {
                updatedProduct.Category = category;
            }
        }

        if (request.Tags is not null)
        {
            var tags = await _tagRepository.GetTagByIds(request.Tags);
            product.ProductTags.Clear();
            foreach (var tag in request.Tags)
            {
                product.ProductTags.Add(new ProductTag
                {
                    Product = product,
                    Tag = tags.SingleOrDefault(x => x.Id == tag)!
                });
            }
        }

        await _productRepository.UpdateProduct(updatedProduct);

        return _mapper.Map<ProductResponse>(updatedProduct);
    }
}
