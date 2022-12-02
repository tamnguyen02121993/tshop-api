using Microsoft.EntityFrameworkCore;
using TShop.Api.EF.Configurations;
using TShop.Api.Models;

namespace TShop.Api.EF;
public class TShopDbContext : DbContext
{
    public const string ConnectionStringSection = "Postgres";
    public DbSet<AppConfig> AppConfigs { get; set; }
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImages> ProductImages { get; set; }
    public DbSet<ProductTag> ProductTags { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public TShopDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
        modelBuilder.SeedCategories();
        modelBuilder.SeedBrands();
        modelBuilder.SeedTags();
    }
}
