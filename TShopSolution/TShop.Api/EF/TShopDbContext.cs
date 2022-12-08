using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TShop.Api.EF.Configurations;
using TShop.Api.Models;

namespace TShop.Api.EF;
public class TShopDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
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

    public DbSet<ApplicationUser> AppliationUsers { get; set; }
    public DbSet<ApplicationRole> ApplicationRoles { get; set; }

    public TShopDbContext(DbContextOptions options) : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);

        modelBuilder.Entity<ApplicationUser>().ToTable("Users");
        modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
        modelBuilder.Entity<IdentityUserClaim<int>>().ToTable("UserClaims");
        modelBuilder.Entity<IdentityUserRole<int>>().ToTable("UserRoles").HasKey(x => new
        {
            x.UserId,
            x.RoleId
        });
        modelBuilder.Entity<IdentityUserLogin<int>>().ToTable("UserLogins").HasKey(x => x.UserId);
        modelBuilder.Entity<IdentityUserToken<int>>().ToTable("UserTokens").HasKey(x => x.UserId);

        modelBuilder.SeedCategories();
        modelBuilder.SeedBrands();
        modelBuilder.SeedTags();

        modelBuilder.SeedRoles();
        modelBuilder.SeedUsers();
    }
}
