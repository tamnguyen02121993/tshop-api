using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;

namespace TShop.Api.EF.Configurations;

public class ProductImagesConfiguration : IEntityTypeConfiguration<ProductImages>
{
    public void Configure(EntityTypeBuilder<ProductImages> builder)
    {
        builder.ToTable("ProductImages");
        builder.HasKey(x => x.Id);

        builder.HasOne(x => x.Product)
               .WithMany(x => x.Images)
               .HasForeignKey(x => x.ProductId);

        builder.Property(x => x.Url).IsRequired();
        builder.Property(x => x.ProductId).IsRequired();
    }
}
