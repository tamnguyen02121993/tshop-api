using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppConfigs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SeoUrl = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Total = table.Column<decimal>(type: "numeric", nullable: false),
                    Tax = table.Column<float>(type: "real", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    NormalizedName = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Slug = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginProvider = table.Column<string>(type: "text", nullable: true),
                    ProviderKey = table.Column<string>(type: "text", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdentityCode = table.Column<string>(type: "text", nullable: true),
                    Birthday = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    RefreshToken = table.Column<string>(type: "text", nullable: true),
                    RefreshTokenExpireTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "text", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LoginProvider = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    SeoUrl = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    SalePrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Warranty = table.Column<int>(type: "integer", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsNewProduct = table.Column<bool>(type: "boolean", nullable: false),
                    IsFeaturedProduct = table.Column<bool>(type: "boolean", nullable: false),
                    IsFavoriteProduct = table.Column<bool>(type: "boolean", nullable: false),
                    Viewed = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    BrandId = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false, defaultValue: 2),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    CommentId = table.Column<Guid>(type: "uuid", nullable: false),
                    ParentCommentId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Comments_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false, defaultValue: 0m),
                    SalePrice = table.Column<decimal>(type: "numeric", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductImages_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTags",
                columns: table => new
                {
                    TagId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTags", x => new { x.ProductId, x.TagId });
                    table.ForeignKey(
                        name: "FK_ProductTags_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Name", "Status", "Summary", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Sexy Forever", 0, "Sexy Forever", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 2, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Trumph", 0, "Trumph", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 3, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "iBasic", 0, "iBasic", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 4, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Uniqlo", 0, "Uniqlo", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 5, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Zara", 0, "Zara", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 6, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Gucci", 0, "Gucci", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 7, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Hermes", 0, "Hermes", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 8, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Louis Vuiton", 0, "Louis Vuiton", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 9, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Chanel", 0, "Chanel", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) },
                    { 10, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135), "Dior", 0, "Dior", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8135) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Name", "SeoUrl", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850), "", "Thời trang nam", "thoi-trang-nam", 0, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850) },
                    { 2, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850), "", "Thời trang nữ", "thoi-trang-nu", 0, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850) },
                    { 3, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850), "", "Nội y nam", "noi-y-nam", 0, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850) },
                    { 4, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850), "", "Nội y nữ", "noi-y-nu", 0, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850) },
                    { 5, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850), "", "Trang sức", "trang-suc", 0, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850) },
                    { 6, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850), "", "Phụ kiện", "phu-kien", 0, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(7850) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "ba43bcb1-48e2-4cb7-a45d-4c2c3aff701b", "Role for super admin", "SuperAdmin", "SUPERADMIN" },
                    { 2, "b215d63c-045d-4bdd-b6ef-12af85f473b9", "Role for admin", "Admin", "ADMIN" },
                    { 3, "884f6bf1-7b57-4f77-be78-38e81106322b", "Role for customer", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Slug", "Status", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "quan-ao", 0, "Quần áo", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 2, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "noi-y", 0, "Nội y", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 3, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "trang-suc", 0, "Trang sức", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 4, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "phu-kien", 0, "Phụ kiện", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 5, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "ao-lot", 0, "Áo lót", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 6, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "quan-lot", 0, "Quần lót", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 7, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "ao-thun", 0, "Áo thun", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 8, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "quan-kaki", 0, "Quần kaki", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 9, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "quan-jean", 0, "Quần jean", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) },
                    { 10, "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170), "ao-khoac", 0, "Áo khoác", "Tam Nguyen", new DateTime(2022, 12, 8, 18, 12, 30, 799, DateTimeKind.Utc).AddTicks(8170) }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "Gender", "IdentityCode", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpireTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, new DateTime(1993, 12, 1, 17, 0, 0, 0, DateTimeKind.Utc), "f855f7bb-236b-453c-bcc1-f0a0500e820b", "tamnguyen02121993@gmail.com", true, 0, "123456789", false, null, "TAMNGUYEN02121993@GMAIL.COM", "TAMNGUYEN02121993", "AQAAAAEAACcQAAAAEAW4LgxgmoWdVE5sY0y9n2F6oq4p6wt+uJqxD8nO7NIkA7Lpu8VO8BHtO6MJYMf64A==", "123456789", true, "", null, "f6e5f018-4cbb-4d41-a2d4-4ba73bd8ff05", false, "tamnguyen02121993" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductImages_ProductId",
                table: "ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTags_TagId",
                table: "ProductTags",
                column: "TagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppConfigs");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductImages");

            migrationBuilder.DropTable(
                name: "ProductTags");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
