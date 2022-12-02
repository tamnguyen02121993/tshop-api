using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.EF.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    private readonly IConfiguration _configuration;
    public BrandConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable("Brands");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Summary).HasMaxLength(500);
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(Status.ACTIVE);
        builder.AddCommonProperties(_configuration);
    }
}