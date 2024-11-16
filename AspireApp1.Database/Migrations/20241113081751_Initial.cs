using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AspireApp1.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreateTime", "Description", "Price", "ProductName", "Quantity" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 13, 16, 17, 51, 158, DateTimeKind.Local).AddTicks(691), "This is product 1", 100.0, "Product 1", 10 },
                    { 2, new DateTime(2024, 11, 13, 16, 17, 51, 158, DateTimeKind.Local).AddTicks(692), "This is product 2", 200.0, "Product 2", 20 },
                    { 3, new DateTime(2024, 11, 13, 16, 17, 51, 158, DateTimeKind.Local).AddTicks(694), "This is product 3", 300.0, "Product 3", 30 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
