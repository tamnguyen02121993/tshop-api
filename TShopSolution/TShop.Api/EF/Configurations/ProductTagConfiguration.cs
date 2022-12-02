using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;

namespace TShop.Api.EF.Configurations;

public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
{
    public void Configure(EntityTypeBuilder<ProductTag> builder)
    {
        builder.ToTable("ProductTags");
        builder.HasKey(x => new
        {
            x.ProductId,
            x.TagId
        });

        builder.HasOne(x => x.Tag)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.TagId);

        builder.HasOne(x => x.Product)
            .WithMany(x => x.ProductTags)
            .HasForeignKey(x => x.ProductId);

        builder.Property(x => x.TagId).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
    }
}
