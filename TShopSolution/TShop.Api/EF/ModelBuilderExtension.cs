using Microsoft.EntityFrameworkCore;
using TShop.Api.Models;
using TShop.Api.Utils.Extensions;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.EF;

public static class ModelBuilderExtension
{
    public static ModelBuilder SeedCategories(this ModelBuilder modelBuilder)
    {
        var author = "Tam Nguyen";
        var date = DateTime.UtcNow;
        var categoryNames = new string[] { "Thời trang nam", "Thời trang nữ", "Nội y nam", "Nội y nữ", "Trang sức", "Phụ kiện" };
        var categories = Enumerable.Range(1, categoryNames.Length).Select(x => new Category
        {
            Id = x,
            Name = categoryNames[x - 1],
            SeoUrl = categoryNames[x - 1].CreateSlugString(),
            Description = string.Empty,
            Status = Status.ACTIVE,
            CreatedBy = author,
            CreatedDate = date,
            UpdatedBy = author,
            UpdatedDate = date

        });
        modelBuilder.Entity<Category>().HasData(categories);
        return modelBuilder;
    }

    public static ModelBuilder SeedBrands(this ModelBuilder modelBuilder)
    {
        var author = "Tam Nguyen";
        var date = DateTime.UtcNow;
        var brandNames = new string[] { "Sexy Forever", "Trumph", "iBasic", "Uniqlo", "Zara", "Gucci", "Hermes", "Louis Vuiton", "Chanel", "Dior" };
        var brands = Enumerable.Range(1, brandNames.Length).Select(x => new Brand
        {
            Id = x,
            Name = brandNames[x - 1],
            Status = Status.ACTIVE,
            Summary = brandNames[x - 1],
            CreatedBy = author,
            CreatedDate = date,
            UpdatedBy = author,
            UpdatedDate = date
        });
        modelBuilder.Entity<Brand>().HasData(brands);
        return modelBuilder;
    }

    public static ModelBuilder SeedTags(this ModelBuilder modelBuilder)
    {
        var author = "Tam Nguyen";
        var date = DateTime.UtcNow;
        var tagTitles = new string[] { "Quần áo", "Nội y", "Trang sức", "Phụ kiện", "Áo lót", "Quần lót", "Áo thun", "Quần kaki", "Quần jean", "Áo khoác" };
        var tags = Enumerable.Range(1, tagTitles.Length).Select(x => new Tag
        {
            Id = x,
            Title = tagTitles[x - 1],
            Slug = tagTitles[x - 1].CreateSlugString(),
            Status = Status.ACTIVE,
            CreatedBy = author,
            CreatedDate = date,
            UpdatedBy = author,
            UpdatedDate = date
        });
        modelBuilder.Entity<Tag>().HasData(tags);
        return modelBuilder;
    }
}
