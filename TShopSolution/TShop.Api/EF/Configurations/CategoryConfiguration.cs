using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;
using TShop.Api.Utils.Extensions;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.EF.Configurations;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    private readonly IConfiguration _configuration;
    public CategoryConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.ToTable("Categories");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.SeoUrl)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Description)
            .HasMaxLength(500);
        
        builder.Property(x => x.Status)
            .IsRequired()
            .HasDefaultValue(Status.ACTIVE);

        builder.AddCommonProperties(_configuration);
    }
}