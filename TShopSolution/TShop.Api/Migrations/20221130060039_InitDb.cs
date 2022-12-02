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
                    { 1, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Sexy Forever", 0, "Sexy Forever", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 2, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Trumph", 0, "Trumph", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 3, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "iBasic", 0, "iBasic", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 4, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Uniqlo", 0, "Uniqlo", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 5, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Zara", 0, "Zara", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 6, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Gucci", 0, "Gucci", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 7, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Hermes", 0, "Hermes", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 8, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Louis Vuiton", 0, "Louis Vuiton", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 9, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Chanel", 0, "Chanel", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) },
                    { 10, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), "Dior", 0, "Dior", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "Name", "SeoUrl", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), "", "Thời trang nam", "thoi-trang-nam", 0, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) },
                    { 2, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), "", "Thời trang nữ", "thoi-trang-nu", 0, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) },
                    { 3, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), "", "Nội y nam", "noi-y-nam", 0, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) },
                    { 4, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), "", "Nội y nữ", "noi-y-nu", 0, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) },
                    { 5, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), "", "Trang sức", "trang-suc", 0, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) },
                    { 6, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), "", "Phụ kiện", "phu-kien", 0, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Slug", "Status", "Title", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "quan-ao", 0, "Quần áo", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 2, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "noi-y", 0, "Nội y", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 3, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "trang-suc", 0, "Trang sức", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 4, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "phu-kien", 0, "Phụ kiện", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 5, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "ao-lot", 0, "Áo lót", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 6, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "quan-lot", 0, "Quần lót", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 7, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "ao-thun", 0, "Áo thun", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 8, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "quan-kaki", 0, "Quần kaki", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 9, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "quan-jean", 0, "Quần jean", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) },
                    { 10, "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), "ao-khoac", 0, "Áo khoác", "Tam Nguyen", new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) }
                });

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
