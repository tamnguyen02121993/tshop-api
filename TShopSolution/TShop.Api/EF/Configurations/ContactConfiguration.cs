using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TShop.Api.Models;
using TShop.Contracts.Utils.Enums;

namespace TShop.Api.EF.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    private readonly IConfiguration _configuration;
    public ContactConfiguration(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.ToTable("Contacts");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
        builder.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(20);
        builder.Property(x => x.Content).IsRequired();
        builder.Property(x => x.Status).IsRequired().HasDefaultValue(ContactStatus.PENDING);
        builder.AddCommonProperties(_configuration);
    }
}
