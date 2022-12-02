using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.EF.Configurations;

public class AppConfigConfiguration : IEntityTypeConfiguration<AppConfig>
{
    private readonly IConfiguration _configuration;
    public AppConfigConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(EntityTypeBuilder<AppConfig> builder)
    {
        builder.ToTable("AppConfigs");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Key).IsRequired().HasMaxLength(500);

        builder.Property(x => x.Value).IsRequired().HasMaxLength(500);

        builder.Property(x => x.Status).IsRequired().HasDefaultValue(Status.ACTIVE);

        builder.AddCommonProperties(_configuration);
    }
}
