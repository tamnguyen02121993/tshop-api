using ErrorOr;
using MediatR;
using TShop.Api.Repositories.Categories;
using TShop.Contracts.Category;
using Microsoft.EntityFrameworkCore;
using MapsterMapper;

namespace TShop.Api.Features.Categories.Queries.GetAvailableCategories;

public class GetAvailableCategoriesQueryHandler : IRequestHandler<GetAvailableCategoriesQuery, List<CategoryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    public GetAvailableCategoriesQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    public async Task<List<CategoryResponse>> Handle(GetAvailableCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAvailableCategories().ToListAsync();
        return _mapper.Map<List<CategoryResponse>>(categories);
    }
}
