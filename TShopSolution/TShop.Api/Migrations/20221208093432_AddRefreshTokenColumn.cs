using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TShop.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddRefreshTokenColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpireTime",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9945) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9628) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a572feca-11ff-460e-8a2c-ab7646299305");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "1f215150-02c7-4685-a281-31444615d627");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977), new DateTime(2022, 12, 8, 9, 34, 32, 438, DateTimeKind.Utc).AddTicks(9977) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "RefreshToken", "RefreshTokenExpireTime", "SecurityStamp" },
                values: new object[] { "28cfc76d-a8c9-4373-bd62-385e43aa4441", "AQAAAAEAACcQAAAAEGQdXc+OfNXmG+iNalYoCeFD8QSnO1mXbKbLM2weCbuYK6pZlq753UdecGehCDwItw==", "", null, "416b5e13-1119-4032-91b8-c9d91cfc495c" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpireTime",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7002) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "bb1fc7f2-4663-43d8-8364-542a3c0c4ab8");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "93d7a274-2d30-429c-9678-fad480a68840");

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475), new DateTime(2022, 12, 7, 14, 51, 23, 257, DateTimeKind.Utc).AddTicks(7475) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ca4a2cc3-5d31-400e-8f29-9ad9fdab5937", "AQAAAAEAACcQAAAAEH4RW8EUxXOQCXYxYwxa19kh+LWCnlm0ifHqbfCp/Xh0ynQu4tsahPqMj2TcBoUNrw==", "117f8753-3d39-429a-989d-7b15f446784f" });
        }
    }
}
