using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddIndentityFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4224) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(3944) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266), new DateTime(2022, 12, 7, 7, 57, 30, 971, DateTimeKind.Utc).AddTicks(4266) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8153) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(7827) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184), new DateTime(2022, 11, 30, 6, 0, 39, 76, DateTimeKind.Utc).AddTicks(8184) });
        }
    }
}
