using TShop.Api.Models;
using TShop.Contracts.Utils.Commons;

namespace TShop.Api.Repositories.Brands;

public interface IBrandRepository
{
    Task<Brand> CreateBrand(Brand brand);
    Task<Brand> UpdateBrand(Brand brand);
    Task DeleteBrand(Brand brand);

    Task<Brand?> GetBrandById(int id);
    IQueryable<Brand> GetAllBrands();
    Task<Pagination<Brand>> GetAllBrands(int pageIndex, int pageSize, string? search);
    IQueryable<Brand> GetAvailableBrands();
    Task<Pagination<Brand>> GetAvailableBrands(int pageIndex, int pageSize, string? search);
}