using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.EF.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(CommentStatus.UNKNOWN);
        builder.Property(x => x.ProductId).IsRequired();
        builder.Property(x => x.CommentId).IsRequired();
    }
}
