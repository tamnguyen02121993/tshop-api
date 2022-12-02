using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.EF.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    private readonly IConfiguration _configuration;
    public ProductConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Category)
               .WithMany(x => x.Products)
               .HasForeignKey(x => x.CategoryId);

        builder.HasOne(x => x.Brand)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.BrandId);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(500);
        builder.Property(x => x.SeoUrl).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Description).IsRequired();
        builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.Quantity).IsRequired().HasDefaultValue(1);
        builder.Property(x => x.Warranty).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.ImageUrl).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(Status.UNKNOWN);
        builder.Property(x => x.IsNewProduct).IsRequired().HasDefaultValue(true);
        builder.Property(x => x.IsFeaturedProduct).IsRequired().HasDefaultValue(true);
        builder.Property(x => x.IsFavoriteProduct).IsRequired().HasDefaultValue(true);
        builder.Property(x => x.Viewed).IsRequired().HasDefaultValue(1);
        builder.Property(x => x.Rating).IsRequired().HasDefaultValue(10);
        builder.Property(x => x.CategoryId).IsRequired();
        builder.Property(x => x.BrandId).IsRequired();

        builder.AddCommonProperties(_configuration);
    }
}
