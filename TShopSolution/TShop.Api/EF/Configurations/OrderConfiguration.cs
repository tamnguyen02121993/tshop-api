using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.EF.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    private readonly IConfiguration _configuration;
    public OrderConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Address).IsRequired().HasMaxLength(500);
        builder.Property(x => x.Total).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.Tax).IsRequired().HasDefaultValue(0);
        builder.Property(x => x.Discount).HasDefaultValue(0);
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(OrderStatus.UNKNOWN);

        builder.AddCommonProperties(_configuration);
    }
}
