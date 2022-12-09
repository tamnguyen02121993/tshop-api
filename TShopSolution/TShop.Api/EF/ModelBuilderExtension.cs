using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TShop.Api.Models;
using TShop.Api.Utils;
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

    public static ModelBuilder SeedRoles(this ModelBuilder modelBuilder)
    {
        var roleNames = new string[] { Constants.SUPER_ADMIN_ROLE, Constants.ADMIN_ROLE, Constants.CUSTOMER_ROLE };
        var roleDescriptions = new string[] { "Role for super admin", "Role for admin", "Role for customer" };

        var roles = Enumerable.Range(1, roleNames.Length).Select(x => new ApplicationRole
        {
            Id = x,
            Description = roleDescriptions[x - 1],
            Name = roleNames[x - 1],
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            //NormalizedName = roleNames[x - 1].ToUpper()
        });
        modelBuilder.Entity<ApplicationRole>().HasData(roles);
        return modelBuilder;
    }

    public static ModelBuilder SeedUsers(this ModelBuilder modelBuilder)
    {
        var names = new string[] { "tamnguyen02121993" };
        var passwords = new string[] { "P@ssw0rd" };
        var passwordHasher = new PasswordHasher<ApplicationUser>();

        var users = Enumerable.Range(1, names.Length).Select(x => new ApplicationUser
        {
            Id = x,
            UserName = names[x - 1],
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            Birthday = DateTime.Parse("12/02/1993").ToUniversalTime(),
            Email = $"{names[x - 1]}@gmail.com",
            Gender = Gender.Male,
            IdentityCode = "123456789",
            EmailConfirmed = true,
            PhoneNumber = "123456789",
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString(),
            //NormalizedEmail = $"{names[x - 1]}@gmail.com".ToUpper(),
            //NormalizedUserName = names[x - 1].ToUpper(),
            PasswordHash = passwordHasher.HashPassword(new ApplicationUser(), passwords[x - 1])
        });

        modelBuilder.Entity<ApplicationUser>().HasData(users);

        var userRoles = new List<IdentityUserRole<int>>();
        // 3 ROLES: SUPPERADMIN, ADMIN, CUSTOMER
        for (int i = 1; i <= 3; i++)
        {
            userRoles.AddRange(Enumerable.Range(1, names.Length).Select(x => new IdentityUserRole<int>
            {
                RoleId = i,
                UserId = x
            }));
        }

        modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);

        return modelBuilder;
    }
}
