using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;
using TShop.Api.Models;
using TShop.Api.Utils.Options;

namespace TShop.Api.EF.Configurations;

public static class CommonConfiguration
{
    public static EntityTypeBuilder AddCommonProperties(this EntityTypeBuilder builder, IConfiguration configurationManager)
    {
        var authorOption = new AuthorOption();
        configurationManager.GetSection(AuthorOption.SectionKey).Bind(authorOption);

        builder.Property("CreatedBy")
           .HasMaxLength(100)
           .HasDefaultValue(authorOption.Name);

        builder.Property("UpdatedBy")
            .HasMaxLength(100)
            .HasDefaultValue(authorOption.Name);

        return builder;
    }
}
