using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Repositories.Categories;
using TShop.Contracts.Category;

namespace TShop.Api.Features.Categories.Queries.GetAllCategories;


public class GetAllCategoriesPaginationQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public GetAllCategoriesPaginationQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<List<CategoryResponse>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAllCategories().ToListAsync();
        return _mapper.Map<List<CategoryResponse>>(categories);
    }
}
